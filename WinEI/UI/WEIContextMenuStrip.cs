// WinEI
// https://github.com/MuertoGB/WinEI

// UI Components
// WEIContextMenuStrip.cs
// Released under the GNU GLP v3.0

using System.Windows.Forms;
using WinEI.UI.Renderers;

namespace WinEI.UI
{
    internal class WEIContextMenuStrip : ContextMenuStrip
    {
        public WEIContextMenuStrip() => Renderer = new WEIMenuRenderer();
    }
}