using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Table
{
    public Guid TableId { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public int? TableNumber { get; set; }

    public int? SeatingCapacity { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public byte? TableType { get; set; }

    public byte? Location { get; set; }

    public bool? IsReserved { get; set; }

    public Guid? ReservationIdFk { get; set; }

    public string? SpecialRequests { get; set; }

    public DateTime? LastReservedAt { get; set; }

    public string? Notes { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
