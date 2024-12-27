using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class LoyaltyProgram
{
    public string? ProgramName { get; set; }

    public int? PointsRequired { get; set; }

    public double? DiscountPercentage { get; set; }

    public int? ValidityPeriod { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? Description { get; set; }

    public string? TermsConditions { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public int? MaxPoints { get; set; }

    public Guid LoyaltyProgramId { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public int? MinPoints { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
