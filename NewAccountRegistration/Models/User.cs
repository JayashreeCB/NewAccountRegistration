using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class User
{
    public int UserId { get; set; }

    public string SingPassId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Salutation { get; set; }

    public string? Designation { get; set; }

    public string? Email { get; set; }

    public int? OfficeNumber { get; set; }

    public int? MobileNumber { get; set; }

    public bool? AllowNotificationBySms { get; set; }

    public bool? AllowNotificationByEmail { get; set; }

    public virtual ICollection<AllocationMapping> AllocationMappings { get; } = new List<AllocationMapping>();

    public virtual ICollection<UserAddressMapping> UserAddressMappings { get; } = new List<UserAddressMapping>();

    public virtual ICollection<UserOrganizationMapping> UserOrganizationMappings { get; } = new List<UserOrganizationMapping>();
}
