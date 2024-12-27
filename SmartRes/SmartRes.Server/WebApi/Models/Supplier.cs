using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Supplier
{
    public Guid SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? TaxId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<SuppliersContact> SuppliersContacts { get; set; } = new List<SuppliersContact>();
}
