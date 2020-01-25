using Flare_Sharp.ClientBase.Categories.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Categories
{
    public class CategoryHandler
    {
        public static CategoryHandler registry;
        public List<ICategory> categories = new List<ICategory>();
        public CategoryHandler()
        {
            registry = this;
            Console.WriteLine("Starting category register...");
            /* Register categories here */
            categories.Add(new Combat());
            categories.Add(new Movement());
            /* Post register categories */
            categories[0].setSelected(true);
            Console.WriteLine("Categories registered!");
            KeybindHandler.clientKeyEvent += onKeyPress;
        }

        public void selectNextCategory()
        {
            int selected = 0;
            foreach(ICategory category in categories)
            {
                if (category.getSelected())
                {
                    break;
                }
                selected++;
            }
            categories[selected].setSelected(false);
            if(selected+1>= categories.Count)
            {
                categories[0].setSelected(true);
            }
            else
            {
                categories[selected + 1].setSelected(true);
            }
        }
        public void selectPrevCategory()
        {
            int selected = 0;
            foreach (ICategory category in categories)
            {
                if (category.getSelected())
                {
                    break;
                }
                selected++;
            }
            categories[selected].setSelected(false);
            if (selected - 1 < 0)
            {
                categories[categories.Count-1].setSelected(true);
            }
            else
            {
                categories[selected - 1].setSelected(true);
            }
        }

        public void onKeyPress(object sender, ClientKeyEvent e)
        {
            if(e.key == 0x28)
            {
                selectNextCategory();
            }
            if (e.key == 0x26)
            {
                selectPrevCategory();
            }
        }
    }
}
