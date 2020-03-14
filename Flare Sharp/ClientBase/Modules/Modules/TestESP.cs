using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
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
            points.Clear();
            points.Add(new RawVector2() { X = Minecraft.clientInstance.localPlayer.currentX1, Y = Minecraft.clientInstance.localPlayer.currentZ1 });
            points.Add(new RawVector2() { X = Minecraft.clientInstance.localPlayer.currentX1+10, Y = Minecraft.clientInstance.localPlayer.currentZ1+10 });
        }
        public override void onRender(RenderTarget target)
        {
            base.onRender(target);
            try
            {

                for (int i = 0; i < points.Count; i += 2)
                {
                    target.DrawLine(points[i], points[i + 1], primaryDx, 1);
                }
            }catch(Exception ex) { }
        }
    }
}
