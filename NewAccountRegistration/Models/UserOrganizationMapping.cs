using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class UserOrganizationMapping
{
    public int UserOrgId { get; set; }

    public int? UserId { get; set; }

    public int? OrganizationId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UserRole { get; set; }

    public bool? IsTaCaccepted { get; set; }

    public virtual ICollection<ApiactivityLog> ApiactivityLogs { get; } = new List<ApiactivityLog>();

    public virtual Organization? Organization { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserActivity> UserActivities { get; } = new List<UserActivity>();

    public virtual ICollection<UserAllocationPermissionsMapping> UserAllocationPermissionsMappings { get; } = new List<UserAllocationPermissionsMapping>();
}
