using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
using Flare_Sharp.ClientBase.UI.VObjs;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.IO
{
    public class FileMan
    {
        public DirectoryInfo configDir = new DirectoryInfo(Environment.CurrentDirectory + "/FlareData");
        public FileInfo configFile
        {
            get
            {
                return new FileInfo(configDir.FullName + "/config.json");
            }
        }
        public static FileMan man;
        public FileMan()
        {
            man = this;
        }

        public void resetConfig()
        {
            if (configFile.Exists)
            {
                configFile.Delete();
            }
            if (configDir.Exists)
            {
                configDir.Delete();
            }
            saveConfig();
        }

        public void saveConfig()
        {
            //Console.WriteLine("Saving...");
            RootObject root = new RootObject();
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    int y = 0;
                    int z = 0;
                    foreach (SliderSetting slider in mod.sliderSettings)
                    {
                        root.moduleSliderSettings.Add(mod.sliderSettings[y].value);
                        y++;
                    }
                    foreach(SliderFloatSetting sliderFloat in mod.sliderFloatSettings)
                    {
                        root.moduleFloatSliderSetting.Add(mod.sliderFloatSettings[z].value);
                        z++;
                    }
                    root.moduleKeybinds.Add(mod.keybind);
                    root.enabledModules.Add(mod.enabled);
                    z++;
                }
            }
            foreach (string targetable in VTargetsWindow.targetable)
            {
                root.targets.Add(targetable);
            }
            string json = new JavaScriptSerializer().Serialize(root);
            if (!configDir.Exists)
            {
                configDir.Create();
            }
            if (!configFile.Exists)
            {
                configFile.Create();
            }
            File.WriteAllText(configFile.FullName, json);
            //Console.WriteLine("Saved!");
        }

        //returns false if it fails
        public bool readConfig()
        {
            try
            {
                if (!configDir.Exists)
                {
                    configDir.Create();
                    return false;
                }
                if (!configFile.Exists)
                {
                    configFile.Create();
                    return false;
                }
                string json = File.ReadAllText(configFile.FullName);
                RootObject root = new JavaScriptSerializer().Deserialize<RootObject>(json);
                int z = 0;
                int y = 0;
                int x = 0;
                foreach (Category cat in CategoryHandler.registry.categories)
                {
                    foreach (Module mod in cat.modules)
                    {
                        foreach (SliderSetting slider in mod.sliderSettings)
                        {
                            slider.value = root.moduleSliderSettings[y];
                            y++;
                        }
                        foreach (SliderFloatSetting sliderFloat in mod.sliderFloatSettings)
                        {
                            sliderFloat.value = root.moduleFloatSliderSetting[x];
                            x++;
                        }
                        mod.keybind = root.moduleKeybinds[z];
                        mod.enabled = root.enabledModules[z];
                        z++;
                    }
                }
                if (VTargetsWindow.instance != null)
                {
                    if (VTargetsWindow.instance.targetObjects != null)
                    {
                        VTargetsWindow.instance.targetObjects.Clear();
                        foreach (string target in root.targets)
                        {
                            //Console.WriteLine("Adding " + target);
                            VStringShelf targetShelf = new VStringShelf();
                            targetShelf.text = target;
                            VTargetsWindow.instance.targetObjects.Add(targetShelf);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                if (MessageBox.Show("Your flare config data is likely corrupt. Click 'OK' to delete it or 'Cancel' to do the same thing. Idc what you want.", "Broken data.", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    resetConfig();
                }
                else
                {
                    resetConfig();
                }
                return false;
            }
        }
    }
}


/*
using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using Flare_Sharp.Memory.VHooks;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Flare_Sharp
{
    class Program
    {
        public static string version = "0.0.7";
        public static int threadSleep = 1;
        public static EventHandler<EventArgs> mainLoop;
        public static bool limitCpu = false;
        static void Main(string[] args)
        {
            //Dont.Be.A.Scumbag.And.Remove.This.Warn.warn();
            Console.WriteLine("Flare# Client");
            Console.WriteLine("Flare port to C#");
            Console.WriteLine("Discord: https://discord.gg/Hz3Dxg8");

            Process.Start("minecraft://");

            try
            {
                MCM.openGame();
                MCM.openWindowHost();

                CommandHook cmh = new CommandHook();
                FileMan fm = new FileMan();
                CategoryHandler ch = new CategoryHandler();
                ModuleHandler mh = new ModuleHandler();
                KeybindHandler kh = new KeybindHandler();
                Thread uiApp = new Thread(() => { OverlayHost ui = new OverlayHost(); Application.Run(ui); });
                if (fm.readConfig())
                {
                    Console.WriteLine("Loaded config!");
                }
                else
                {
                    Console.WriteLine("Could not load config!");
                }
                uiApp.Start();
                if(args != null)
                {
                    if (args.Length > 0)
                    {
                        if (args[0] == "dualThread")
                        {
                            Thread moduleThread = new Thread(() => { while (true) { try { ModuleHandler.registry.tickModuleThread(); Thread.Sleep(1); } catch (Exception) { } } });
                            moduleThread.Start();
                        }
                    }
                }
                while (true)
                {
                    try
                    {
                        mainLoop.Invoke(null, new EventArgs());
                        if(limitCpu)
                            Thread.Sleep(1);
                    }
                    catch (Exception)
                    {

                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Stacktrace: " + ex.StackTrace);
                MessageBox.Show("Flare crashed! Check the console for error details. Click 'Ok' to quit.");
            }
        }
    }
}
*/