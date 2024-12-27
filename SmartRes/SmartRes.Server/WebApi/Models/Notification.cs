using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Notification
{
    public Guid NotificationId { get; set; }

    public string? Message { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? NotificationType { get; set; }

    public Guid? RelatedId { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? Priority { get; set; }

    public byte? Status { get; set; }

    public string? CustomerFeedback { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public DateTime? ResponseDate { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }
}
