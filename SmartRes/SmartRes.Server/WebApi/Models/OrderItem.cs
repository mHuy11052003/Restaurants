using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class OrderItem
{
    public string? SpecialRequests { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid OrderItemId { get; set; }

    public Guid? OrderIdFk { get; set; }

    public Guid? ItemIdFk { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public decimal? Discount { get; set; }

    public bool? IsRefunded { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? ItemNotes { get; set; }

    public string? Allergens { get; set; }

    public string? SpiceLevel { get; set; }

    public virtual MenuItem? ItemIdFkNavigation { get; set; }

    public virtual Order? OrderIdFkNavigation { get; set; }
}
