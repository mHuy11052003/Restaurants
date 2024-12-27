using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class MenuItem
{
    public Guid ItemId { get; set; }

    public Guid? MenuIdFk { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ImageUrl { get; set; }

    public string? ItemType { get; set; }

    public string? SpiceLevel { get; set; }

    public int? Calories { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public byte? Status { get; set; }

    public string? Allergens { get; set; }

    public virtual Menu? MenuIdFkNavigation { get; set; }

    public virtual ICollection<MenuItemsIngredient> MenuItemsIngredients { get; set; } = new List<MenuItemsIngredient>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
