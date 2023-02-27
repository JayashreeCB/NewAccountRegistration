using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserAllocationPermissionsMapping> UserAllocationPermissionsMappings { get; } = new List<UserAllocationPermissionsMapping>();
}
