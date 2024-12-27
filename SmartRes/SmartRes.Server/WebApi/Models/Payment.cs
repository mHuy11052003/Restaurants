using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid? OrderIdFk { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMethod { get; set; }

    public byte? Status { get; set; }

    public string? TransactionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? CustomerIdFk { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public decimal? RefundAmount { get; set; }

    public byte? RefundStatus { get; set; }

    public string? PaymentNotes { get; set; }

    public string? Currency { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual Order? OrderIdFkNavigation { get; set; }
}
