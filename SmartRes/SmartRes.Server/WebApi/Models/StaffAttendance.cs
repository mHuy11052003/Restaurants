using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class StaffAttendance
{
    public Guid AttendanceId { get; set; }

    public Guid StaffIdFk { get; set; }

    public DateTime AttendanceDate { get; set; }

    public DateTime CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public decimal? TotalHours { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Staff StaffIdFkNavigation { get; set; } = null!;
}
