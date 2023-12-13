namespace Inventory.DTOs.InventoryStock
{
    public class InventoryStockToEditDTO
    {
         public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}