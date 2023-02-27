using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class UserAllocationPermissionsMapping
{
    public int UserAllocationPermissionId { get; set; }

    public int AllocationMappingId { get; set; }

    public int UserOrgId { get; set; }

    public int PermissionId { get; set; }

    public bool IsAllowed { get; set; }

    public virtual AllocationMapping AllocationMapping { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;

    public virtual UserOrganizationMapping UserOrg { get; set; } = null!;
}
