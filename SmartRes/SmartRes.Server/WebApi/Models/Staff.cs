using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Staff
{
    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public TimeOnly? ShiftStartTime { get; set; }

    public Guid StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ProfilePicture { get; set; }

    public Guid? RestaurantIdFk { get; set; }

    public TimeOnly? ShiftEndTime { get; set; }

    public virtual Restaurant? RestaurantIdFkNavigation { get; set; }

    public virtual ICollection<StaffAttendance> StaffAttendances { get; set; } = new List<StaffAttendance>();

    public virtual ICollection<StaffLeave> StaffLeaves { get; set; } = new List<StaffLeave>();

    public virtual ICollection<StaffSalary> StaffSalaries { get; set; } = new List<StaffSalary>();

    public virtual ICollection<StaffSchedule> StaffSchedules { get; set; } = new List<StaffSchedule>();
}
