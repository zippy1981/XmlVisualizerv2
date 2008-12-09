// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System.IO;
using Microsoft.Win32;

namespace XmlVisualizer
{
    public static class Util
    {
        private const string registryKey = @"Software\XmlVisualizer2\";

        public static void DeleteFile(string fileToDelete)
        {
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
        }

        public static void SaveToRegistry(string keyName, string value)
        {
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey sk = rk.CreateSubKey(registryKey);

            if (sk != null) sk.SetValue(keyName, value);
        }

        public static string ReadFromRegistry(string keyName)
        {
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey sk = rk.CreateSubKey(registryKey);

            string returnValue = "";

            if (sk != null)
            {
                if (sk.GetValue(keyName) != null) returnValue = sk.GetValue(keyName).ToString();
            }

            return returnValue;
        }

        public static void SaveComboBoxItemToRegistry(string saveValue, string keyName, int numberOfFilesToSave)
        {
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey sk = rk.CreateSubKey(registryKey);

            int bottomPos = numberOfFilesToSave - 1;

            for (int i = 1; i <= numberOfFilesToSave; i++)
            {
                if (sk != null)
                {
                    try
                    {
                        if (sk.GetValue(keyName + i).ToString() == saveValue)
                        {
                            sk.DeleteValue(keyName + i);
                            bottomPos = i - 1;
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            for (int i = bottomPos; i >= 1; i--)
            {
                string checkValue = "";

                try
                {
                    if (sk != null) checkValue = sk.GetValue(keyName + i).ToString();
                }
                catch
                {
                }

                if (checkValue == "") continue;

                if (sk != null) sk.SetValue(keyName + (i + 1), checkValue);
            }

            if (sk != null) sk.SetValue(keyName + "1", saveValue);
        }

        public static string GetTitle()
        {
            System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            object[] attributes = thisAssembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);

            string title = "";

            if (attributes.Length == 1)
            {
                title = ((System.Reflection.AssemblyTitleAttribute)attributes[0]).Title;
            }

            return title;
        }

        public static void ShowMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, GetTitle(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static string GetDetailedErrorMessage(System.Exception e)
        {
            return e.InnerException != null ? e.InnerException.Message : e.Message;
        }

        public static string GetDefaultWebBrowser()
        {
            RegistryKey rk = Registry.ClassesRoot;
            RegistryKey sk = rk.CreateSubKey(@"HTTP\shell\open\command");

            string returnValue = "";

            if (sk != null)
            {
                returnValue = sk.GetValue(null).ToString();

                int startPos = returnValue.IndexOf((char)34);
                int endPos = returnValue.IndexOf((char)34, startPos + 1);

                returnValue = returnValue.Substring(startPos + 1, endPos - 1);
            }

            if (returnValue == "")
            {
                returnValue = "iexplore.exe";
            }

            return returnValue;
        }
    }
}
