using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Menu
{
    public string? MenuName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public bool? IsSpecial { get; set; }

    public string? PriceRange { get; set; }

    public string? MenuType { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? AvailableFrom { get; set; }

    public DateTime? AvailableTo { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid MenuId { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
