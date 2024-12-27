using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class StaffLeave
{
    public Guid LeaveId { get; set; }

    public Guid StaffIdFk { get; set; }

    public DateOnly LeaveDate { get; set; }

    public string? LeaveType { get; set; }

    public string? LeaveReason { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Staff StaffIdFkNavigation { get; set; } = null!;
}
