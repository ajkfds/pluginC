using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = codeEditor.Data;

namespace pluginC.FileTypes
{
    public class CSourceFile : codeEditor.FileTypes.FileType
    {
        public override string ID { get => "CSoourceFile"; }

        public override bool IsThisFileType(string relativeFilePath, codeEditor.Data.Project project)
        {
            if (
                relativeFilePath.ToLower().EndsWith(".c")
            )
            {
                return true;
            }
            return false;
        }

        public override codeEditor.Data.File CreateFile(string relativeFilePath, codeEditor.Data.Project project)
        {
            return Data.CSourceFile.Create(relativeFilePath, project);
        }

    }
}
