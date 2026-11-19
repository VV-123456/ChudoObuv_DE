namespace ChudoObuv.Models
{
    public class CartItem
    {
        public int StockItemId { get; set; } 
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}