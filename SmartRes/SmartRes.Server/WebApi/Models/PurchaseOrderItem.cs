using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class PurchaseOrderItem
{
    public Guid PurchaseOrderItemId { get; set; }

    public Guid? PurchaseOrderIdFk { get; set; }

    public Guid? IngredientIdFk { get; set; }

    public decimal? QuantityOrdered { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual PurchaseOrder? PurchaseOrderIdFkNavigation { get; set; }
}
