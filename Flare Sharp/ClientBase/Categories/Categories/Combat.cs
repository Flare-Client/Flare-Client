using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Categories.Categories
{
    public class Combat : ICategory
    {
        bool active = false;
        bool selected = false;
        public Combat() { }
        public bool getActive()
        {
            return active;
        }

        public string getName()
        {
            return "Combat";
        }

        public bool getSelected()
        {
            return selected;
        }

        public void setActive(bool active)
        {
            this.active = active;
        }

        public void setSelected(bool selected)
        {
            this.selected = selected;
        }
    }
}
