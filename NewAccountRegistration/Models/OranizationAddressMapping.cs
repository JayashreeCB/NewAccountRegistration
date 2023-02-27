using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class OranizationAddressMapping
{
    public int OrganizationAddressId { get; set; }

    public int OranizationId { get; set; }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual Organization Oranization { get; set; } = null!;
}
