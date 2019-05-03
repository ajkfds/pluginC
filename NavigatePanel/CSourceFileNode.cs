using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pluginC.NavigatePanel
{
    public class CSourceFileNode : codeEditor.NavigatePanel.FileNode
    {
        public CSourceFileNode(string ID, codeEditor.Data.Project project) : base(ID, project)
        {

        }

        public codeEditor.Data.ITextFile ITextFile
        {
            get => Project.GetRegisterdItem(ID) as codeEditor.Data.ITextFile;
        }

        public override string Text
        {
            get => FileItem.Name;
        }

        private static ajkControls.IconImage icon = new ajkControls.IconImage(Properties.Resources.c);
        public override void DrawNode(Graphics graphics, int x, int y, Font font, Color color, Color backgroundColor, Color selectedColor, int lineHeight, bool selected)
        {
            graphics.DrawImage(icon.GetImage(lineHeight, ajkControls.IconImage.ColorStyle.White), new Point(x, y));
            Color bgColor = backgroundColor;
            if (selected) bgColor = selectedColor;
            System.Windows.Forms.TextRenderer.DrawText(
                graphics,
                Text,
                font,
                new Point(x + lineHeight + (lineHeight >> 2), y),
                color,
                bgColor,
                System.Windows.Forms.TextFormatFlags.NoPadding
                );
        }

        public override void Selected()
        {
            codeEditor.Global.Controller.CodeEditor.SetTextFile(ITextFile);
        }
    }
}
