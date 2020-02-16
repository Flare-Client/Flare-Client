using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VTargetsWindow : VWindowBase
    {
        VAddButton addBtn;
        List<VStringShelf> targetObjects = new List<VStringShelf>();
        public VTargetsWindow(double x) : base(x)
        {
            addBtn = new VAddButton();
            addBtn.width = width;
            addBtn.height = 24;
            VStringShelf shelff = new VStringShelf();
            shelff.width = width;
            shelff.height = 24;
            targetObjects.Add(shelff);
            addBtn.clicked += (object a, EventArgs b)=>{
                VStringShelf shelf = new VStringShelf();
                shelf.width = width;
                shelf.height = 24;
                targetObjects.Add(shelf);
            };
            text = "Targets";
        }

        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            double z = 25;
            try
            {
                foreach (VStringShelf shelf in targetObjects)
                {
                    if (shelf.deleted)
                    {
                        targetObjects.Remove(shelf);
                        OverlayHost.ui.repaint();
                        continue;
                    }
                    shelf.x = x;
                    shelf.y = y + z;
                    shelf.OnPaint(e);
                    z += shelf.height;
                }
            }
            catch (Exception) { }
            addBtn.y = y + z;
            addBtn.x = x;
            addBtn.OnPaint(e);
        }
    }
}
