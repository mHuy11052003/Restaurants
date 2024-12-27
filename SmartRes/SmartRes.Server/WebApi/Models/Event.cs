using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Event
{
    public Guid EventId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public int? MaxAttendees { get; set; }

    public decimal? TicketPrice { get; set; }

    public string? ImageUrl { get; set; }

    public string? SpecialRequests { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public byte? EventType { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
