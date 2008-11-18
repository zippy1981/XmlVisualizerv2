// Xml Visualizer v.2
// by Lars Hove Christiansen (larshove@gmail.com)
// http://www.codeplex.com/XmlVisualizer

using System;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace XmlVisualizer
{
    public partial class EditorUserControl : UserControl
    {
        public delegate void CaretChangeEventHandler(int line, int column);
        public event CaretChangeEventHandler CaretChangeEvent;

        private static bool textChanged;
        
        public EditorUserControl()
        {
            InitializeComponent();

            textEditorControl.TabIndent = 3;
            textEditorControl.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("XML");

            textEditorControl.ActiveTextAreaControl.Caret.PositionChanged += Caret_PositionChanged;
            textEditorControl.Document.DocumentChanged += Document_DocumentChanged;
        }

        void Caret_PositionChanged(object sender, EventArgs e)
        {
            int line = textEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            int column = textEditorControl.ActiveTextAreaControl.Caret.Column + 1;

            CaretChangeEvent(line, column);
        }

        static void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            textChanged = true;
        }

        public string GetText()
        {
            return textEditorControl.Text;
        }

        public void SetText(string text)
        {
            bool modified = ChangesInEditor;
            textEditorControl.Text = text;
            textEditorControl.Refresh();
            ChangesInEditor = modified;
        }

        public void SetFocus()
        {
            textEditorControl.Focus();
        }

        public void GotoLine(int line, int column)
        {
            textEditorControl.ActiveTextAreaControl.Caret.Line = line - 1;
            textEditorControl.ActiveTextAreaControl.Caret.Column = column - 1;
            textEditorControl.ActiveTextAreaControl.CenterViewOn(line - 1, 0);
            textEditorControl.Focus();
        }

        public bool ChangesInEditor
        {
            get
            {
                return textChanged;
            }
            set
            {
                textChanged = value;
            }
        }

        private void toolStripMenuItemRedo_Click(object sender, EventArgs e)
        {
            textEditorControl.Redo();
        }

        private void toolStripMenuItemUndo_Click(object sender, EventArgs e)
        {
            textEditorControl.Undo();
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textEditorControl.Document.UndoStack.CanUndo)
            {
                toolStripMenuItemUndo.Enabled = true;
            }
            else
            {
                toolStripMenuItemUndo.Enabled = false;
            }

            if (textEditorControl.Document.UndoStack.CanRedo)
            {
                toolStripMenuItemRedo.Enabled = true;
            }
            else
            {
                toolStripMenuItemRedo.Enabled = false;
            }
        }

        private void toolStripMenuItemCut_Click(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
        }

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
        }

        private void toolStripMenuItemSelectAll_Click(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e);
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            textEditorControl.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e);
        }

        public void Search(string searchText)
        {
            if (searchText.Trim().Trim().Length == 0)
            {
                return;
            }

            int startIndex = textEditorControl.ActiveTextAreaControl.Caret.Offset;

            if (startIndex > textEditorControl.Document.TextContent.ToLower().LastIndexOf(searchText.ToLower()))
            {
                startIndex = 0;
            }

            int offset = textEditorControl.Document.TextContent.ToLower().IndexOf(searchText.ToLower(), startIndex);

            if (offset >= 0)
            {
                TextLocation startPosition = textEditorControl.Document.OffsetToPosition(offset);
                TextLocation endPosition = textEditorControl.Document.OffsetToPosition(offset + searchText.Length);

                textEditorControl.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);

                GotoLine(textEditorControl.Document.GetLineNumberForOffset(offset) + 1, startPosition.Column + searchText.Length + 1);
            }
            else
            {
                Util.ShowMessage(string.Format("'{0}' not found.", searchText));
            }
        }
    }
}
