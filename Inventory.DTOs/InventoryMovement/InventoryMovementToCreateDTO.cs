namespace Inventory.DTOs.InventoryMovement
{
    public class InventoryMovementToCreateDTO
    {
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int MovementTypeId { get; set; }
    }
}
