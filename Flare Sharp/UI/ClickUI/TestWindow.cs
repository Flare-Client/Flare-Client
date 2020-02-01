using Flare_Sharp.UI.ClickUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.ClickUI
{
    public class TestWindow : CUIWindow
    {
        public TestWindow() : base()
        {
            controls.Add(new CUILabel("Settings", "Arial", 32, FontStyle.Underline, Color.FromArgb(255, 255, 255), 10, 10, this));
            visible = true;
        }
    }
}
