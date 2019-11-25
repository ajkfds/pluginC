using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluginC.Parser
{
    public class Parser : codeEditor.CodeEditor.DocumentParser
    {
        public Parser(Data.CSourceFile file, codeEditor.CodeEditor.DocumentParser.ParseModeEnum parseMode) : base (file,parseMode)
        {
        }

        public override void Parse()
        {
            string text = document.CreateString();
            int index = text.IndexOf("int");
            if(index != -1)
            {
                for (int i = 0; i < 3; i++)
                {
                    document.SetColorAt(index + i, (byte)Style.Color.Keyword);
                }
            }
        }
    }
}
