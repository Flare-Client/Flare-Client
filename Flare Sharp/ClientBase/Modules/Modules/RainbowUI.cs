using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.UI;
using System;
using System.Drawing;
using System.Timers;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class RainbowUI : VisualModule
    {
        public RainbowUI() : base("Rainbow UI", CategoryHandler.registry.categories[3], 0x07, false)
        {
            OverlayHost.postOverlayLoad += (object sen, EventArgs e) =>
              {
                  Timer rgbTimer = new Timer(10);
                  rgbTimer.Elapsed += (object send, ElapsedEventArgs arg) =>
                  {
                      OverlayHost.ui.rainbowProg += 0.01f;
                  };
                  rgbTimer.Start();
              };
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        void draw()
        {
            Graphics g = OverlayHost.ui.CreateGraphics();
            //Rainbow around main tab gui
            if(TabGUI.instance.enabled)
                g.DrawRectangle(new Pen(rainbow.Color, 1), 0, 0, TabGUI.instance.catWidth, TabGUI.instance.catHeight);

            //Rainbow for enabled modules
            if (ModuleList.instance.enabled)
            {
                uint yOff = 0;
                foreach (Category cat in CategoryHandler.registry.categories)
                {
                    foreach (Module mod in cat.modules)
                    {
                        if (mod.enabled)
                        {
                            float mwid = g.MeasureString(mod.name, textFont, 600).Width;
                            g.FillRectangle(rainbow, OverlayHost.ui.width - mwid - 5, (32 * scale) * yOff, 5, fontSize);
                            yOff++;
                        }
                    }
                }
            }

            g.Flush();
            g.Dispose();
        }

        public override void onTick()
        {
            draw();
        }
        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            draw();
        }
    }
}
