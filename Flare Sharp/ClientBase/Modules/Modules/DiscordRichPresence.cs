using DiscordRPC;
using DiscordRPC.Message;
using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    class DiscordRichPresence : Module
    {
        public DiscordRpcClient client;

        public DiscordRichPresence() : base("DiscordRPC", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
            startTimer(150);
		}

		public override void onTimedTick()
        {
            base.onTimedTick();

			if(client != null) { client.Invoke(); Console.WriteLine($"DiscordRPC client: {client}"); }
        }

        public override void onEnable()
        {
            base.onEnable();

			client = new DiscordRpcClient("685869994235527284");
			client.OnReady += (sender, e) => onReady(sender, e);

			client.OnPresenceUpdate += (sender, e) => onPresenceUpdate(sender, e);

			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				Details = "A bedrock client",
				State = $"TBD",
				Assets = new Assets()
				{
					LargeImageKey = "icon",
					LargeImageText = "Flare-Client!",
					SmallImageKey = "flarelogo"
				}
			});
			Console.WriteLine(Minecraft.clientInstance.localPlayer.username);
		}
        public override void onDisable()
        {
            base.onDisable();

			client.Dispose();
        }

		private void onReady(object sender, ReadyMessage m)
		{
			Console.WriteLine($"Ready received: {m.User.Username} ({m.User.ID})");
		}

		private void onPresenceUpdate(object sender, PresenceMessage m)
		{
			Console.WriteLine($"Update received: {m.Presence}");
		}
	}
}
