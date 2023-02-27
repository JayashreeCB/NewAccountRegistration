using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class AllocationMapping
{
    public int AllocationMappingId { get; set; }

    public int PropertyAllocationId { get; set; }

    public int? OrganizationId { get; set; }

    public int? UserId { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual Allocation PropertyAllocation { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ICollection<UserAllocationPermissionsMapping> UserAllocationPermissionsMappings { get; } = new List<UserAllocationPermissionsMapping>();
}
