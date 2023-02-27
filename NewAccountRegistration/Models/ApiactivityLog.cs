using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class ApiactivityLog
{
    public int ApiactivityId { get; set; }

    public int UserOrgId { get; set; }

    public string Apiname { get; set; } = null!;

    public DateTime TriggerTime { get; set; }

    public string ResponseStatus { get; set; } = null!;

    public virtual UserOrganizationMapping UserOrg { get; set; } = null!;
}
