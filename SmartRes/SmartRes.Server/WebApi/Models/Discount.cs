using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Discount
{
    public Guid DiscountId { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public string? DiscountCode { get; set; }

    public double? DiscountPercentage { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? DiscountDescription { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
