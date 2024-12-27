using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Reservation
{
    public Guid ReservationId { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public DateTime? ReservationDate { get; set; }

    public int? NumberOfPeople { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? SpecialRequests { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public int? TableNumber { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public int? LoyaltyPointsUsed { get; set; }

    public string? ConfirmationCode { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
