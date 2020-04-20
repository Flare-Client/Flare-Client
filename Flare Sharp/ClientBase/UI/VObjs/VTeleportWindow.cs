
using Flare_Sharp.Memory.FlameSDK;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VTeleportWindow : VWindowBase
    {
        public static VTeleportWindow instance;
        VButton teleportButton = new VButton("TP");
        public List<VIntStringShelf> xyzInputs = new List<VIntStringShelf>();
        public static List<string> xyz 
        {
            get
            {
                List<string> returned = new List<string>();
                if (instance != null)
                {
                    if (instance.xyzInputs != null)
                    {
                        foreach (VIntStringShelf shelf in instance.xyzInputs)
                        {
                            returned.Add(shelf.text);
                        }
                    }
                }
                return returned;
            }
        }
        public VTeleportWindow(int x) : base(x)
        {
            instance = this;

            VIntStringShelf xEntry = new VIntStringShelf();
            xEntry.width = width;
            xEntry.height = 24;

            VIntStringShelf yEntry = new VIntStringShelf();
            yEntry.width = width;
            yEntry.height = 24;

            VIntStringShelf zEntry = new VIntStringShelf();
            zEntry.width = width;
            zEntry.height = 24;

            xyzInputs.Add(xEntry);
            xyzInputs.Add(yEntry);
            xyzInputs.Add(zEntry);

            teleportButton.width = width;
            teleportButton.height = 24;

            teleportButton.clicked += (object a, EventArgs b) => {
                Minecraft.clientInstance.localPlayer.teleport(float.Parse(xEntry.text), float.Parse(yEntry.text), float.Parse(zEntry.text));
            };

            text = "Teleport";
            //We have to register this manually
            OverlayHost.ui.Paint += (object sender, PaintEventArgs e) =>
            {
                if (visible)
                {
                    OnPaint(e);
                }
            };
        }

        public override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int z = 25;
            try
            {
                foreach (VIntStringShelf shelf in xyzInputs)
                {
                    if (shelf.deleted)
                    {
                        xyzInputs.Remove(shelf);
                        OverlayHost.ui.Invalidate();
                        continue;
                    }
                    shelf.x = x;
                    shelf.y = y + z;
                    shelf.OnPaint(e);
                    z += shelf.height;
                }
            }
            catch (Exception) { }
            teleportButton.y = y + z;
            teleportButton.x = x;
            teleportButton.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(quinary), x, y + height, width - 1, z - 1);
        }
    }
}
