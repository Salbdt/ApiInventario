namespace Inventory.DTOs.InventoryStock
{
    public class InventoryStockToCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}