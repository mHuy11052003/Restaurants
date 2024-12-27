using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class MenuItemsIngredient
{
    public Guid MenuitemsIngredientId { get; set; }

    public Guid MenuitemsIdFk { get; set; }

    public Guid IngredientIdFk { get; set; }

    public decimal Quantity { get; set; }

    public string? Unit { get; set; }

    public virtual Inventory IngredientIdFkNavigation { get; set; } = null!;

    public virtual MenuItem MenuitemsIdFkNavigation { get; set; } = null!;
}
