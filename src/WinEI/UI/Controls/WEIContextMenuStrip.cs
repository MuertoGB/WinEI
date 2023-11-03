// WinEI
// https://github.com/MuertoGB/WinEI

// UI Components
// WEIContextMenuStrip.cs
// Released under the GNU GLP v3.0

using System.Drawing;
using System.Windows.Forms;
using WinEI.UI.Renderers;

namespace WinEI.UI
{
    public class WEIContextMenuStrip : ContextMenuStrip
    {
        public WEIContextMenuStrip()
        {
            Renderer = new WEIMenuRenderer();
            BackColor = Color.FromArgb(25, 25, 25);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10.2f, FontStyle.Regular);
            ShowImageMargin = false;
        }
    }
}