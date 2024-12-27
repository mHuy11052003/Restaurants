using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class StaffSalary
{
    public Guid SalaryId { get; set; }

    public Guid StaffIdFk { get; set; }

    public DateOnly PaymentMonth { get; set; }

    public decimal BasicSalary { get; set; }

    public decimal? Allowance { get; set; }

    public decimal TotalSalary { get; set; }

    public decimal NetSalary { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Staff StaffIdFkNavigation { get; set; } = null!;
}
