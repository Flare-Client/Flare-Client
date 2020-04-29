using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Drawing;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class CoordinatesDisplay : VisualModule
    {

        public CoordinatesDisplay() : base("Coordinate UI", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
        }

        public override void onDraw(System.Drawing.Graphics graphics)
        {
            base.onDraw(graphics);
            if(MCM.readInt64(Minecraft.clientInstance.localPlayer.addr) > 0)
            {
                MCM.RECT mcRect = MCM.getMinecraftRect();
                float playerX = Minecraft.clientInstance.localPlayer.currentX3, playerY = Minecraft.clientInstance.localPlayer.currentY3, playerZ = Minecraft.clientInstance.localPlayer.currentZ3;
                string formatText = Math.Floor(playerX).ToString() + ":" + Math.Floor(playerY - 1).ToString() + ":" + Math.Floor(playerZ).ToString();
                graphics.DrawString(formatText, textFont, primary, 0, mcRect.Top * 130);
            }
        }
    }
}
