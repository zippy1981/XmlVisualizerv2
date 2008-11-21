// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XmlVisualizer
{
    public partial class TreeViewUserControl : UserControl
    {
        public delegate void StatusTextEventEventHandler(string statusText);
        public event StatusTextEventEventHandler StatusTextEvent;
        
        private int findIndex;
        private int hitCount;
        private int numberOfHits;
        private string previousSearchString;
        private static bool searchActivated;

        public TreeViewUserControl()
        {
            InitializeComponent();
        }

        public void SetFocus()
        {
            searchTreeTextBox.Focus();
        }

        public bool ReloadTreeView(string xml)
        {
            bool success = true;
            
            try
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(xml);

                treeView.Nodes.Clear();

                if (dom.DocumentElement != null)
                {
                    treeView.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
                }

                AddNodeToTree(dom.DocumentElement, treeView.Nodes[0]);
                treeView.ExpandAll();

                treeView.Nodes[0].EnsureVisible();
            }
            catch (Exception e)
            {
                Util.ShowMessage(Util.GetDetailedErrorMessage(e));
                success = false;
            }

            return success;
        }

        private static void AddNodeToTree(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            XmlNodeList nodeList;

            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;

                for (int i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];

                    StringBuilder attributes = new StringBuilder();

                    if (xNode.Attributes != null)
                    {
                        foreach (XmlAttribute attribute in xNode.Attributes)
                        {
                            attributes.Append(string.Format(" {0}=\"{1}\"", attribute.Name, attribute.Value));
                        }
                    }

                    inTreeNode.Nodes.Add(new TreeNode(string.Format("{0}{1}", xNode.Name, attributes)));
                    TreeNode tNode = inTreeNode.Nodes[i];
                    AddNodeToTree(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        private void ExpandTreeButton_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
            treeView.Nodes[0].EnsureVisible();
        }

        private void CollapseTreeButton_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
            treeView.Nodes[0].Expand();
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            if (searchActivated)
            {
                SearchTreeNext();
            }
        }

        private void FindPreviousButton_Click(object sender, EventArgs e)
        {
            if (searchActivated)
            {
                SearchTreePrevious();
            }
        }

        private void FindByText()
        {
            ClearBackColor();
            hitCount = 0;

            if (searchTreeTextBox.Text.Trim() == "")
            {
                return;
            }

            TreeNodeCollection nodes = treeView.Nodes;

            foreach (TreeNode node in nodes)
            {
                FindRecursive(node);
            }

            numberOfHits = hitCount;

            if (numberOfHits == 0)
            {
                Util.ShowMessage(string.Format("'{0}' not found.", searchTreeTextBox.Text));
            }
        }

        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text.ToLower().Contains(searchTreeTextBox.Text.ToLower()))
                {
                    hitCount++;
                    node.BackColor = Color.Yellow;

                    if (hitCount == findIndex)
                    {
                        node.BackColor = Color.Blue;
                        node.ForeColor = Color.White;
                        treeView.SelectedNode = node;
                        node.EnsureVisible();
                    }
                }

                FindRecursive(node);
            }
        }

        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView.Nodes;

            foreach (TreeNode node in nodes)
            {
                ClearRecursive(node);
            }
        }

        private static void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.ForeColor = Color.Black;
                node.BackColor = Color.White;
                ClearRecursive(node);
            }
        }

        private void SearchTreeNext()
        {
            findIndex++;

            if (previousSearchString != searchTreeTextBox.Text.ToLower())
            {
                previousSearchString = searchTreeTextBox.Text.ToLower();
                findIndex = 1;
            }

            if (findIndex > numberOfHits)
            {
                findIndex = 1;
            }

            FindByText();
        }

        private void SearchTreePrevious()
        {
            findIndex--;

            if (previousSearchString != searchTreeTextBox.Text.ToLower())
            {
                previousSearchString = searchTreeTextBox.Text.ToLower();
                FindByText();
                findIndex = numberOfHits;
            }

            if (findIndex == 0)
            {
                findIndex = numberOfHits;
            }

            FindByText();
        }

        private void SearchTreeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchTreeNext();
            }
        }

        private void expandTreeButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Expand all nodes");
        }

        private void expandTreeButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void collapseTreeButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Collapse all nodes");
        }

        private void collapseTreeButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void searchTreeTextBox_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Search in Tree");
        }

        private void searchTreeTextBox_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void findPreviousButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Find previous occurence of search text");
        }

        private void findPreviousButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void findNextButton_MouseEnter(object sender, EventArgs e)
        {
            StatusTextEvent("Find next occurence of search text");
        }

        private void findNextButton_MouseLeave(object sender, EventArgs e)
        {
            StatusTextEvent("");
        }

        private void searchTreeTextBox_Enter(object sender, EventArgs e)
        {
            if (!searchActivated)
            {
                searchTreeTextBox.ForeColor = Color.Black;
                searchTreeTextBox.Text = "";
                searchActivated = true;
            }
        }

        private void searchTreeTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTreeTextBox.Text == "")
            {
                searchTreeTextBox.ForeColor = SystemColors.GradientInactiveCaption;
                searchTreeTextBox.Text = "Search...";
                searchActivated = false;
            }
        }
    }
}
