using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string Uen { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LegalEntity { get; set; }

    public virtual ICollection<AllocationMapping> AllocationMappings { get; } = new List<AllocationMapping>();

    public virtual ICollection<OranizationAddressMapping> OranizationAddressMappings { get; } = new List<OranizationAddressMapping>();

    public virtual ICollection<UserOrganizationMapping> UserOrganizationMappings { get; } = new List<UserOrganizationMapping>();
}
