using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Flare_Sharp.ClientBase.UI.VObjs
{
    public class VCatgoryWindow : VWindowBase
    {
        List<VModuleItem> moduleObjects = new List<VModuleItem>();
        public Category category;
        public VCatgoryWindow(Category category, double x) : base(x)
        {
            this.category = category;
            this.text = category.name;

            foreach(Module module in category.modules)
            {
                VModuleItem VMI = new VModuleItem(module, this);
                foreach(SliderSetting sliderSetting in VMI.module.sliderSettings)
                {
                    VMI.children.Add(new VModuleSliderSetting(sliderSetting, VMI));
                }
                moduleObjects.Add(VMI);
            }
        }

        public override void OnPaint(DrawingContext e)
        {
            base.OnPaint(e);
            double paintOffset = 0;
            foreach (VObject vObject in moduleObjects)
            {
                vObject.x = x;
                vObject.y = y + height + paintOffset;
                vObject.OnPaint(e);
                paintOffset += vObject.height;
            }
            //e.DrawRectangle(null, new Pen(rainbow), x, y + height, width-1, paintOffset);
        }
    }
}
