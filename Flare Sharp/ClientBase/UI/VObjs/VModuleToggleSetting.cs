using Flare_Sharp.ClientBase.Modules.Settings;
namespace Flare_Sharp.ClientBase.UI.VObjs
{
    class VModuleToggleSetting : VToggleItem
    {
        ToggleSetting setting;
        public override bool value
        {
            get
            {
                return setting.value;
            }
            set
            {
                if (setting != null)
                    setting.value = value;
            }
        }
        public VModuleToggleSetting(ToggleSetting setting, VShelfItem parent) : base(setting.text, setting.value, parent)
        {
            this.setting = setting;
        }
    }
}
