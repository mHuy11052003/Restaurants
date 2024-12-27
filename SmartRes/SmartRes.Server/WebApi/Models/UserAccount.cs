using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class UserAccount
{
    public Guid UserId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public byte? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public string? ProfilePicture { get; set; }

    public string? Preferences { get; set; }

    public bool? TwoFactorEnabled { get; set; }

    public DateTime? LastPasswordChange { get; set; }

    public Guid? RoleIdFk { get; set; }

    public virtual UserRole? RoleIdFkNavigation { get; set; }
}
