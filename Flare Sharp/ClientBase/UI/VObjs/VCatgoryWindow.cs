using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
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
    public class VCatgoryWindow : VWindowBase
    {
        List<VModuleItem> moduleObjects = new List<VModuleItem>();
        public Category category;
        public VCatgoryWindow(Category category, int x) : base(x)
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
                foreach (SliderFloatSetting sliderFloatSetting in VMI.module.sliderFloatSettings)
                {
                    VMI.children.Add(new VModuleFloatSliderSetting(sliderFloatSetting, VMI));
                }
                foreach (ToggleSetting toggleSetting in VMI.module.toggleSettings)
                {
                    VMI.children.Add(new VModuleToggleSetting(toggleSetting, VMI));
                }
                moduleObjects.Add(VMI);

            }

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
            int paintOffset = 0;
            foreach (VObject vObject in moduleObjects)
            {
                vObject.x = x;
                vObject.y = y + height + paintOffset;
                vObject.OnPaint(e);
                paintOffset += vObject.height;
            }
            e.Graphics.DrawRectangle(new Pen(quinary), x, y + height, width-1, paintOffset);
        }
    }
}
