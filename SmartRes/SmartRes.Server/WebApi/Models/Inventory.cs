using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Inventory
{
    public Guid InventoryId { get; set; }

    public string IngredientName { get; set; } = null!;

    public string? Unit { get; set; }

    public decimal QuantityInStock { get; set; }

    public Guid? SupplierIdFk { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<MenuItemsIngredient> MenuItemsIngredients { get; set; } = new List<MenuItemsIngredient>();

    public virtual Supplier? SupplierIdFkNavigation { get; set; }
}
