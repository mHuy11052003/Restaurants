using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Review
{
    public DateTime? ResponseDate { get; set; }

    public int? HelpfulVotes { get; set; }

    public bool? IsAnonymous { get; set; }

    public byte? ReviewType { get; set; }

    public Guid ReviewId { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public double? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? Response { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
