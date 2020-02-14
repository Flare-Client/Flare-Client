using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.UI.TabUI
{
    public class TabUiHandler
    {
        public static TabUiHandler instance;

        float scale = 1;
        int tFontSize = 72;
        int fontSize = 32;
        Font titleFont;
        Font textFont;
        public float catWidth = 0;
        public float modWidth = 0;

        public TabUiHandler()
        {
            instance = this;
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        internal void renderMLUI(Graphics graphics)
        {

            //Draw enabled modules
            uint yOff = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        float mwid = graphics.MeasureString(mod.name, textFont, 600).Width;
                        graphics.FillRectangle(OverlayHost.ui.secondary, OverlayHost.ui.width - mwid, (32 * scale) * yOff, mwid, fontSize);
                        graphics.DrawString(mod.name, textFont, OverlayHost.ui.rainbow, OverlayHost.ui.width - mwid, (32 * scale) * yOff);
                        yOff++;
                    }
                }
            }
        }

        internal void renderTUI(Graphics graphics)
        {
            //Adjust fonts
            titleFont = new Font(new FontFamily("Arial"), tFontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
            textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);

            graphics.FillRectangle(OverlayHost.ui.secondary, 0, 0, catWidth * scale, ((32 * scale) * CategoryHandler.registry.categories.Count) + tFontSize);

            //graphics.FillRectangle(OverlayHost.ui.secondary, 0, 0, catWidth * scale, 32 * scale);
            graphics.DrawString("Flare", titleFont, OverlayHost.ui.rainbow, -13, 0);
            uint c = 0;
            foreach (Category category in CategoryHandler.registry.categories)
            {
                float wid = graphics.MeasureString(category.name, textFont, 600).Width;
                if (wid > catWidth)
                {
                    catWidth = wid;
                }
            }
            foreach (Category category in CategoryHandler.registry.categories)
            {
                //Draw category
                if (category.active)
                {
                    graphics.FillRectangle(OverlayHost.ui.secondary, catWidth, tFontSize, modWidth * scale, (32 * scale) * category.modules.Count);
                    graphics.FillRectangle(OverlayHost.ui.quaternary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                    //Draw modules
                    foreach (Module module in category.modules)
                    {
                        float wid = graphics.MeasureString(module.name, textFont, 400).Width;
                        if (wid > modWidth)
                        {
                            modWidth = wid;
                        }
                    }
                    uint m = 0;
                    foreach (Module module in category.modules)
                    {
                        //graphics.DrawRectangle(new Pen(OverlayHost.ui.rainbow), catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        if(module.enabled && module.selected)
                        {
                            graphics.FillRectangle(OverlayHost.ui.quaternary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        else if (module.enabled)
                        {
                            graphics.FillRectangle(OverlayHost.ui.rainbow, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        else if (module.selected)
                        {
                            graphics.FillRectangle(OverlayHost.ui.tertiary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        graphics.DrawString(module.name, textFont, OverlayHost.ui.primary, catWidth, tFontSize + (32 * scale) * m);
                        float kwid = graphics.MeasureString(module.keybind.ToString(), textFont, 200).Width;
                        graphics.FillRectangle(OverlayHost.ui.secondary, catWidth + modWidth, tFontSize + (32 * scale) * m, kwid * scale, 32 * scale);
                        graphics.DrawString(module.keybind.ToString(), textFont, OverlayHost.ui.primary, catWidth + modWidth, tFontSize + (32 * scale) * m);
                        m++;
                    }
                    graphics.DrawRectangle(new Pen(OverlayHost.ui.rainbow, 5), catWidth, tFontSize, modWidth * scale, (32 * scale) * category.modules.Count);
                }
                else if (category.selected)
                {
                    graphics.FillRectangle(OverlayHost.ui.tertiary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                }
                graphics.DrawString(category.name, textFont, OverlayHost.ui.primary, 0, tFontSize + (32 * scale) * c);
                c++;
            }
            graphics.DrawRectangle(new Pen(OverlayHost.ui.rainbow,5), 0, 0, catWidth * scale, ((32 * scale)* CategoryHandler.registry.categories.Count)+ tFontSize);
        }
    }
}
