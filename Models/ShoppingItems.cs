namespace ShoppingList.Models
{
    public class ShoppingItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bought { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
