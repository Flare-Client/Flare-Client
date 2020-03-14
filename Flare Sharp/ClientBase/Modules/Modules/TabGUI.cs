using Flare_Sharp.ClientBase.Categories;
using System.Drawing;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TabGUI : VisualModule
    {
        public float catWidth = 0;
        public float modWidth = 0;
        public float catHeight = 0;
        public float modHeight = 0;

        public static TabGUI instance;

        public TabGUI() : base("TabGUI", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
            instance = this;
        }

        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);

            graphics.FillRectangle(secondary, 0, 0, catWidth * scale, ((32 * scale) * CategoryHandler.registry.categories.Count) + tFontSize);

            //graphics.FillRectangle(secondary, 0, 0, catWidth * scale, 32 * scale);
            graphics.DrawString("Flare", titleFont, primary, -13, 0);
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
                    graphics.FillRectangle(secondary, catWidth, tFontSize, modWidth * scale, (32 * scale) * category.modules.Count);
                    graphics.FillRectangle(quaternary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
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
                        //graphics.DrawRectangle(new Pen(rainbow), catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        if (module.enabled && module.selected)
                        {
                            graphics.FillRectangle(quaternary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        else if (module.enabled)
                        {
                            graphics.FillRectangle(quinary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        else if (module.selected)
                        {
                            graphics.FillRectangle(tertiary, catWidth, tFontSize + (32 * scale) * m, modWidth * scale, 32 * scale);
                        }
                        graphics.DrawString(module.name, textFont, primary, catWidth, tFontSize + (32 * scale) * m);
                        float kwid = graphics.MeasureString(module.keybind.ToString(), textFont, 200).Width;
                        graphics.FillRectangle(secondary, catWidth + modWidth, tFontSize + (32 * scale) * m, kwid * scale, 32 * scale);
                        graphics.DrawString(module.keybind.ToString(), textFont, primary, catWidth + modWidth, tFontSize + (32 * scale) * m);
                        m++;
                    }
                    graphics.DrawRectangle(new Pen(quinary, 1), catWidth, tFontSize, modWidth * scale, (32 * scale) * category.modules.Count);
                }
                else if (category.selected)
                {
                    graphics.FillRectangle(tertiary, 0, tFontSize + (32 * scale) * c, catWidth * scale, 32 * scale);
                }
                graphics.DrawString(category.name, textFont, primary, 0, tFontSize + (32 * scale) * c);
                c++;
            }
            catHeight = ((32 * scale) * CategoryHandler.registry.categories.Count) + tFontSize;
            graphics.DrawRectangle(new Pen(quinary, 1), 0, 0, catWidth * scale, ((32 * scale) * CategoryHandler.registry.categories.Count) + tFontSize);
        }
    }
}
