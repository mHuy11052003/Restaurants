using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public byte? Status { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? SpecialRequests { get; set; }

    public bool? IsPaid { get; set; }

    public TimeOnly? DeliveryTime { get; set; }

    public string? CustomerFeedback { get; set; }

    public string? DiscountCode { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
