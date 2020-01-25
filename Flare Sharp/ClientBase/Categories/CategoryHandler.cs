using Flare_Sharp.ClientBase.Categories.Categories;
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
            Console.WriteLine("Categories registered!");
        }
    }
}
