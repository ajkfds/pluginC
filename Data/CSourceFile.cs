using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ajkControls;
using codeEditor.CodeEditor;

namespace pluginC.Data
{
    public class CSourceFile : codeEditor.Data.TextFile
    {
        public static new CSourceFile Create(string relativePath, codeEditor.Data.Project project)
        {
            //string id = GetID(relativePath, project);

            CSourceFile fileItem = new CSourceFile();
            fileItem.Project = project;
            fileItem.RelativePath = relativePath;
            if (relativePath.Contains('\\'))
            {
                fileItem.Name = relativePath.Substring(relativePath.LastIndexOf('\\') + 1);
            }
            else
            {
                fileItem.Name = relativePath;
            }

            return fileItem;
        }



        protected override codeEditor.NavigatePanel.NavigatePanelNode createNode()
        {
            return new codeEditor.NavigatePanel.TextFileNode(this);
        }

        public new virtual codeEditor.CodeEditor.DocumentParser CreateDocumentParser(DocumentParser.ParseModeEnum parseMode)
        {
            return new Parser.Parser(this,parseMode);
        }


    }
}
