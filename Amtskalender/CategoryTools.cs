using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amtskalender
{
    static class CategoryTools
    {
        public static List<string> SplitCategories(string Categories)
        {
            if (Categories == null) Categories = "";
            List<string> Cats = Categories.Split(';').Select(p => p.Trim()).ToList();
            return Cats;
        }

        public static string AddCategory(string Categories, string Category)
        {
            List<string> Cats = SplitCategories(Categories);
            Cats.Add(Category);
            return String.Join(";", Cats.ToArray());
        }

        public static string RemoveCategory(string Categories, string Category)
        {
            List<string> Cats = SplitCategories(Categories);
            Cats.Remove(Category);
            return String.Join(";", Cats.ToArray());
        }

        public static bool HasCategory(string CategoriesString, string Category)
        {
            List<string> Categories = SplitCategories(CategoriesString);
            foreach (string ThisCategory in Categories) if (Category == ThisCategory) return true;
            return false;
        }

    }
}
