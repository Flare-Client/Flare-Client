using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.Modules.Settings;
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

        public void saveConfig()
        {
            Console.WriteLine("Saving...");
            RootObject root = new RootObject();
            int z = 0;
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    root.moduleKeybinds.Add(mod.keybind);
                    root.enabledModules.Add(mod.enabled);
                    z++;
                }
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
            Console.WriteLine("Saved!");
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
                foreach (Category cat in CategoryHandler.registry.categories)
                {
                    foreach (Module mod in cat.modules)
                    {
                        mod.keybind = root.moduleKeybinds[z];
                        mod.enabled = root.enabledModules[z];
                        z++;
                    }
                }
                return true;
            } catch(Exception)
            {
                MessageBox.Show("Your flare config data is likely corrupt. Please delete it. Path: " + configFile.FullName);
                return false;
            }
        }
    }
}
