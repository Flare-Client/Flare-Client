using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VTargetsWindow : VWindowBase
    {
        List<VStringShelf> targetObjects = new List<VStringShelf>();
        public VTargetsWindow(int x) : base(x)
        {
            text = "Targets";
            //We have to register this manually
            OverlayHost.ui.Paint += (object sender, PaintEventArgs e) =>
            {
                if (visible)
                {
                    OnPaint(e);
                }
            };
        }
    }
}
