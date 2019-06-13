using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluginC
{
    public class Plugin : codeEditorPlugin.IPlugin
    {
        public bool Register()
        {
            // register filetype
            FileTypes.CSourceFile fileType = new FileTypes.CSourceFile();
            codeEditor.Global.FileTypes.Add(fileType.ID, fileType);
            return true;
        }

        public bool Initialize()
        {
            return true;
        }

        public string Id { get { return "C"; } }
    }
}
