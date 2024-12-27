using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class SuppliersContact
{
    public Guid ContactId { get; set; }

    public Guid SupplierIdFk { get; set; }

    public string ContactName { get; set; } = null!;

    public string? ContactTitle { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? DetailedAddress { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual Supplier SupplierIdFkNavigation { get; set; } = null!;
}
