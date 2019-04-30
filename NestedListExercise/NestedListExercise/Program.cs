using System;
using System.Collections.Generic;
using System.Linq;

namespace NestedListExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Item> items = new List<Item>
            {
                new Item{ItemId = 1, Name = "Item1", subItemOfId = 0},
                new Item{ItemId = 2, Name = "Item2", subItemOfId = 0},
                new Item{ItemId = 3, Name = "Item3", subItemOfId = 0},
                new Item{ItemId = 4, Name = "Item10", subItemOfId = 1},
                new Item{ItemId = 5, Name = "Item11", subItemOfId = 1},
                new Item{ItemId = 6, Name = "Item12", subItemOfId = 1},
                new Item{ItemId = 7, Name = "Item100", subItemOfId = 4},
                new Item{ItemId = 8, Name = "Item101", subItemOfId = 4},
                new Item{ItemId = 9, Name = "Item102", subItemOfId = 4},
                new Item{ItemId = 10, Name = "Item30", subItemOfId = 3},
                new Item{ItemId = 11, Name = "Item31", subItemOfId = 3},
                new Item{ItemId = 12, Name = "Item32", subItemOfId = 3},

                new Item{ItemId = 20, Name = "Food", subItemOfId = 0},
                new Item{ItemId = 21, Name = "Vegetables", subItemOfId = 20},
                new Item{ItemId = 22, Name = "Fruit", subItemOfId = 20},
                new Item{ItemId = 23, Name = "Onion", subItemOfId = 21},
                new Item{ItemId = 24, Name = "Squash", subItemOfId = 21},
                new Item{ItemId = 25, Name = "Pineapple", subItemOfId = 22},
                new Item{ItemId = 26, Name = "Orange", subItemOfId = 22},
                new Item{ItemId = 27, Name = "Meat", subItemOfId = 20},
                new Item{ItemId = 28, Name = "Beef", subItemOfId = 27},
                new Item{ItemId = 29, Name = "Ground Chuck", subItemOfId = 28},
                new Item{ItemId = 30, Name = "Ribeye", subItemOfId = 28},
                new Item{ItemId = 31, Name = "Chicken", subItemOfId = 27},
            };

            var itemsByParent = items.GroupBy(x => x.subItemOfId);
            var root = new TreeNode();

            foreach (var group in itemsByParent)
            {
                if (group.Key == 0)
                {
                    foreach (var item in group)
                    {
                        root.Children.Add(new TreeNode(item));
                    }
                }
                else
                {
                    var node = root.Find(group.Key);

                    foreach (var item in group)
                    {
                        node?.Children.Add(new TreeNode(item));
                    }
                }
            }

            Print(root);
            Console.ReadKey();
        }

        public static void Print(TreeNode node) => Print(node, string.Empty);

        public static void Print(TreeNode tree, string prevIndent)
        {
            var indent = prevIndent + "    ";

            if (tree.Item == null)
            {
                indent = prevIndent;
            }

            if (tree.Item != null)
                Console.WriteLine(prevIndent + tree.Item.Name);

            foreach (var child in tree.Children)
            {
                Print(child, string.Concat(indent));
            }
        }
    }
}
