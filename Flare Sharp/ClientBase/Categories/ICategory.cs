using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Categories
{
    public interface ICategory
    {
        bool getSelected();
        void setSelected(bool selected);
        bool getActive();
        void setActive(bool active);
        string getName();
    }
}
