using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class PurchaseOrder
{
    public Guid PurchaseOrderId { get; set; }

    public Guid? SupplierIdFk { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier? SupplierIdFkNavigation { get; set; }
}
