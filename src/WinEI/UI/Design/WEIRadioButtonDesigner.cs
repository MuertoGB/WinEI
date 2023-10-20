// WinEI
// https://github.com/MuertoGB/WinEI

// UI Components
// WEIRadioButtonDesigner.cs
// Released under the GNU GLP v3.0

using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.Design;

namespace WinEI.UI.Design
{
    internal class WEIRadioButtonDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary Properties)
        {
            List<string> PropList = new List<string>
            {
                "Appearance",
                "BackgroundImage",
                "BackgroundImageLayout",
                "CheckAlign",
                "FlatAppearance",
                "FlatStyle",
                "Image",
                "ImageAlign",
                "ImageIndex",
                "ImageKey",
                "ImageList",
                "RightToLeft",
                "TextAlign",
                "TextImageRelation",
                "UseVisualStyleBackColor",
                "Padding",
                "AutoEllipsis"
            };

            if (Properties != null)
                foreach (string Item in PropList)
                    Properties.Remove(Item);

            base.PreFilterProperties(Properties);
        }
    }
}