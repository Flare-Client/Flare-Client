using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Flare_Sharp.ClientBase.IO
{
    public class FileMan
    {
        public DirectoryInfo configDir = new DirectoryInfo(Environment.CurrentDirectory+"/FlareData");
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
            int z = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    int y = 0;
                    foreach (SliderSetting slider in mod.sliderSettings)
                    {
                        root.moduleSliderSettings.Add(mod.sliderSettings[y].value);
                        y++;
                    }
                    root.moduleKeybinds.Add(mod.keybind);
                    root.enabledModules.Add(mod.enabled);
                    z++;
                }
            }
            foreach(string targetable in EntityList.targetable)
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
                foreach (Category cat in CategoryHandler.registry.categories)
                {
                    foreach (Module mod in cat.modules)
                    {
                        foreach (SliderSetting slider in mod.sliderSettings)
                        {
                            slider.value = root.moduleSliderSettings[y];
                            y++;
                        }
                        mod.keybind = root.moduleKeybinds[z];
                        mod.enabled = root.enabledModules[z];
                        z++;
                    }
                }
                if (VTargetsWindow.instance != null)
                {
                    if(VTargetsWindow.instance.targetObjects != null)
                    {
                        VTargetsWindow.instance.targetObjects.Clear();
                        foreach(string target in root.targets)
                        {
                            Console.WriteLine("Adding " + target);
                            VStringShelf targetShelf = new VStringShelf();
                            targetShelf.text = target;
                            VTargetsWindow.instance.targetObjects.Add(targetShelf);
                        }
                    }
                }
                return true;
            } catch(Exception)
            {
                if(MessageBox.Show("Your flare config data is likely corrupt. Click 'OK' to delete it or 'Cancel' to do the same thing. Idc what you want.", "Broken data.", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
