using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class AddressType
{
    public int AddressTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<OranizationAddressMapping> OranizationAddressMappings { get; } = new List<OranizationAddressMapping>();

    public virtual ICollection<UserAddressMapping> UserAddressMappings { get; } = new List<UserAddressMapping>();
}
