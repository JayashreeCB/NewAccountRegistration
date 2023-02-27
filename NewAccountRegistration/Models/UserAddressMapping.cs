using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class UserAddressMapping
{
    public int UserAddressId { get; set; }

    public int UserId { get; set; }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
