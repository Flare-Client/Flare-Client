using Flare_Sharp.ClientBase.Categories;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TestESP : VisualModule
    {
        public TestESP():base("TestESP", CategoryHandler.registry.categories[3], 0x07, false)
        {
        }

        List<RawVector2> points = new List<RawVector2>();
        public override void onTick()
        {
            base.onTick();

        }
        public override void onRender(RenderTarget target)
        {
            base.onRender(target);
            for (int i = 0; i < points.Count; i += 2)
            {
                target.DrawLine(points[i], points[i + 1], primaryDx, 1);
            }
        }
    }
}
