using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ajkControls;
using codeEditor.CodeEditor;

namespace pluginC.Data
{
    public class CSourceFile : codeEditor.Data.File, codeEditor.Data.ITextFile
    {
        public new static CSourceFile Create(string relativePath, codeEditor.Data.Project project)
        {
            string id = GetID(relativePath, project);
            if (project.IsRegistered(id))
            {
                CSourceFile item = project.GetRegisterdItem(id) as CSourceFile;
                project.RegisterProjectItem(item);
                return item;
            }

            CSourceFile fileItem = new CSourceFile();
            fileItem.Project = project;
            fileItem.ID = id;
            fileItem.RelativePath = relativePath;
            if (relativePath.Contains('\\'))
            {
                fileItem.Name = relativePath.Substring(relativePath.LastIndexOf('\\') + 1);
            }
            else
            {
                fileItem.Name = relativePath;
            }

            project.RegisterProjectItem(fileItem);
            return fileItem;
        }


        public bool IsCodeDocumentCashed
        {
            get { if (document == null) return false; else return true; }
        }

        private volatile bool parseRequested = false;
        public bool ParseRequested { get { return parseRequested; } set { parseRequested = value; } }

        private volatile bool reloadRequested = false;
        public bool ReloadRequested { get { return reloadRequested; } set { reloadRequested = value; } }
        public void Reload()
        {
            CodeDocument = null;
        }
        public override void DisposeItem()
        {
            if (ParsedDocument != null) ParsedDocument.Dispose();
            base.DisposeItem();
        }

        public codeEditor.CodeEditor.ParsedDocument ParsedDocument { get; set; }

        private codeEditor.CodeEditor.CodeDocument document = null;
        public codeEditor.CodeEditor.CodeDocument CodeDocument
        {
            get
            {
                if (document == null)
                {
                    try
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(Project.GetAbsolutePath(RelativePath)))
                        {
                            document = new codeEditor.CodeEditor.CodeDocument();
                            string text = sr.ReadToEnd();
                            document.Replace(0, 0, 0, text);
                        }
                    }
                    catch
                    {
                        document = null;
                    }
                }
                return document;
            }
            protected set
            {
                document = value;
            }
        }

        public CodeDrawStyle DrawStyle
        {
            get
            {
                return codeEditor.Global.DefaultDrawStyle;
            }
        }

        public override codeEditor.NavigatePanel.NavigatePanelNode CreateNode()
        {
            return new codeEditor.NavigatePanel.TextFileNode(ID, Project);
        }

        public virtual codeEditor.CodeEditor.DocumentParser CreateDocumentParser(codeEditor.CodeEditor.CodeDocument document, string id, codeEditor.Data.Project project,DocumentParser.ParseModeEnum parseMode)
        {
            return new Parser.Parser(document, id, project,parseMode);
        }

        public virtual void AfterKeyPressed(System.Windows.Forms.KeyPressEventArgs e)
        {

        }
        public virtual void AfterKeyDown(System.Windows.Forms.KeyEventArgs e)
        {

        }
        public virtual void BeforeKeyPressed(System.Windows.Forms.KeyPressEventArgs e)
        {
        }

        public virtual void BeforeKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
        }

        public List<codeEditor.CodeEditor.PopupItem> GetPopupItems(int EditId, int index)
        {
            return null;
        }

        public List<AutocompleteItem> GetAutoCompleteItems(int index,out string cantidateWord)
        {
            cantidateWord = null;
            return null;
        }

        public List<codeEditor.CodeEditor.ToolItem> GetToolItems(int index)
        {
            return null;
        }

    }
}
