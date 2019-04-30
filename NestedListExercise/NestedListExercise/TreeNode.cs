using System;
using System.Collections.Generic;
using System.Linq;

namespace NestedListExercise
{
    public class TreeNode
    {
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public TreeNode(Item item) : this()
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public bool Contains(int itemId)
        {
            if (Item?.ItemId == itemId)
                return true;
            if (!Children.Any())
                return false;
            return Children.Any(x => x.Contains(itemId));
        }

        public TreeNode Find(int itemId)
        {
            if (Item?.ItemId == itemId)
                return this;
            if (!Contains(itemId))
                return null;

            // There should only ever be zero or one child trees containing a given id, but it's not enforced in this class.
            // That's why this SingleOrDefault is ugly.
            return Children.Where(x => x.Contains(itemId)).SingleOrDefault().Find(itemId);
        }

        public override string ToString()
        {
            return
    $@"{Item?.Name}
{nameof(Children)}:{Children.Count}";
        }

        public Item Item { get; set; }
        public IList<TreeNode> Children { get; set; }
    }
}
