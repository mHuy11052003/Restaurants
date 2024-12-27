using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class InventoryTransaction
{
    public Guid TransactionId { get; set; }

    public Guid InventoryIdFk { get; set; }

    public decimal? QuantityChanged { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? TransactionReason { get; set; }

    public Guid? TransactionBy { get; set; }

    public virtual Inventory InventoryIdFkNavigation { get; set; } = null!;
}
