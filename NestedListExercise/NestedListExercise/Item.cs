namespace NestedListExercise
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int subItemOfId { get; set; }

        public override string ToString()
        {
            return
    $@"{nameof(ItemId)}:{ItemId}
{nameof(Name)}:{Name}
{nameof(subItemOfId)}:{subItemOfId}";
        }
    }
}
