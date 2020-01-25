using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Categories
{
    public class Category
    {
        public string name;
        public bool active;
        public bool selected;
        public Category(string name, bool active, bool selected)
        {
            this.name = name;
            this.active = active;
            this.selected = selected;
        }
    }
}
