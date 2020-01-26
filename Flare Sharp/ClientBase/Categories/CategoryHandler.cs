using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using System;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Categories
{
    public class CategoryHandler
    {
        public static CategoryHandler registry;
        public List<Category> categories = new List<Category>();
        public CategoryHandler()
        {
            registry = this;
            Console.WriteLine("Starting category register...");
            /* Register categories here */
            categories.Add(new Category("Combat", false, true));
            categories.Add(new Category("Movement", false, false));
            categories.Add(new Category("Player", false, false));
            categories.Add(new Category("Misc", false, false));
            Console.WriteLine("Categories registered!");
            KeybindHandler.clientKeyDownEvent += onKeyPress;
        }

        public Category activeCategory()
        {
            foreach(Category cat in categories)
            {
                if (cat.active)
                {
                    return cat;
                }
            }
            return null;
        }

        public void selectNextCategory()
        {
            int selected = 0;
            foreach(Category category in categories)
            {
                if (category.active)
                {
                    return;
                }
                if (category.selected)
                {
                    break;
                }
                selected++;
            }
            categories[selected].selected = false;
            if(selected+1>= categories.Count)
            {
                categories[0].selected = true;
            }
            else
            {
                categories[selected + 1].selected = true;
            }
        }
        public void selectPrevCategory()
        {
            int selected = 0;
            foreach (Category category in categories)
            {
                if (category.active)
                {
                    return;
                }
                if (category.selected)
                {
                    break;
                }
                selected++;
            }
            categories[selected].selected = false;
            if (selected - 1 < 0)
            {
                categories[categories.Count-1].selected = true;
            }
            else
            {
                categories[selected - 1].selected = true;
            }
        }
        public void activateSelectedCategory()
        {
            int selected = 0;
            foreach (Category category in categories)
            {
                if (category.selected)
                {
                    break;
                }
                selected++;
            }
            categories[selected].active = true;
            if (categories[selected].modules.Count > 0)
            {
                foreach(Module m in categories[selected].modules)
                {
                    if (m.selected)
                    {
                        return;
                    }
                }
                categories[selected].modules[0].selected = true;
            }
        }
        public void deactivateSelectedCategory()
        {
            int selected = 0;
            foreach (Category category in categories)
            {
                if (category.selected)
                {
                    break;
                }
                selected++;
            }
            categories[selected].active = false;
        }

        public void onKeyPress(object sender, clientKeyEvent e)
        {
            if(e.key == 0x28)
            {
                selectNextCategory();
            }
            if (e.key == 0x26)
            {
                selectPrevCategory();
            }
            if (e.key == 0x27)
            {
                activateSelectedCategory();
            }
            if (e.key == 0x25)
            {
                deactivateSelectedCategory();
            }
        }
    }
}
