using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string PostalCode { get; set; } = null!;

    public string BuildingName { get; set; } = null!;

    public string StreetName { get; set; } = null!;

    public string HouseNo { get; set; } = null!;

    public string? Country { get; set; }

    public string? LevelNumber { get; set; }

    public string? UnitNumber { get; set; }

    public bool? IsMailingAddressDifferent { get; set; }

    public bool? IsBillingAddressDifferent { get; set; }

    public virtual ICollection<OranizationAddressMapping> OranizationAddressMappings { get; } = new List<OranizationAddressMapping>();

    public virtual ICollection<UserAddressMapping> UserAddressMappings { get; } = new List<UserAddressMapping>();
}
