using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class StaffSchedule
{
    public Guid ScheduleId { get; set; }

    public Guid StaffIdFk { get; set; }

    public DateOnly WorkDate { get; set; }

    public string Shift { get; set; } = null!;

    public DateTime? ShiftStartTime { get; set; }

    public DateTime? ShiftEndTime { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Staff StaffIdFkNavigation { get; set; } = null!;
}
