using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class Allocation
{
    public int PropertyAllocationId { get; set; }

    public string AllocationId { get; set; } = null!;

    public string AllocationType { get; set; } = null!;

    public string IndustryType { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public string? PropertyAdress { get; set; }

    public virtual ICollection<AllocationMapping> AllocationMappings { get; } = new List<AllocationMapping>();
}
