using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class UserRole
{
    public Guid Id { get; set; }

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
