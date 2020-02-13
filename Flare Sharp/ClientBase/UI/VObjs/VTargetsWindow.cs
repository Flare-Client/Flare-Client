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
        VAddButton addBtn;
        List<VStringShelf> targetObjects = new List<VStringShelf>();
        public VTargetsWindow(int x) : base(x)
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
            //We have to register this manually
            OverlayHost.ui.Paint += (object sender, PaintEventArgs e) =>
            {
                if (visible)
                {
                    OnPaint(e);
                }
                addBtn.visible = visible;
            };
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int z = 24;
            try
            {
                foreach (VStringShelf shelf in targetObjects)
                {
                    if (shelf.deleted)
                    {
                        targetObjects.Remove(shelf);
                        OverlayHost.ui.Invalidate();
                        continue;
                    }
                    shelf.visible = visible;
                    shelf.x = x;
                    shelf.y = y + z;
                    shelf.OnPaint(e);
                    z += shelf.height;
                }
            }
            catch (Exception) { }
            addBtn.visible = visible;
            addBtn.y = y + z;
            addBtn.x = x;
            addBtn.OnPaint(e);
        }
    }
}
