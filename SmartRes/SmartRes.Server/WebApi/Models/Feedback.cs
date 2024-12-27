using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Feedback
{
    public Guid FeedbackId { get; set; }

    public string? FeedbackText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? Response { get; set; }

    public DateTime? ResponseDate { get; set; }

    public byte? FeedbackType { get; set; }

    public bool? IsAnonymous { get; set; }

    public double? Rating { get; set; }

    public int? HelpfulVotes { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public bool? IsResolved { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }
}
