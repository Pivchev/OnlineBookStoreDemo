namespace OnlineBookStoreDemo.Services
{
    using System;
    using System.Linq;

    using OnlineBookStoreDemo.Data.Models;

    public class TraverseTreeDFS
    {
        public static void TraverseTree(Category category, string spaces)
        {
            // Visit the current directory
            Console.WriteLine(spaces + category.Name);

            Category[] children = category.SubCategories.ToArray();

            // For each child go and visit its subtree
            foreach (Category child in children)
            {
                TraverseTree(child, spaces + "  ");
            }
        }
    }
}
