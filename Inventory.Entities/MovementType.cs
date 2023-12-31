namespace Inventory.Entities
{
    public class MovementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsIncoming { get; set; }
        public bool IsOutGoing { get; set; }
        public bool IsInternalTransfer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }  

        // Relations
        public IEnumerable<InventoryMovement>? InventoryMovements { get; set; }
    }
}