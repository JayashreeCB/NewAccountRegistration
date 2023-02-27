using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class UserActivity
{
    public int UserActivityId { get; set; }

    public int UserOrgId { get; set; }

    public string ActivtiyDescripton { get; set; } = null!;

    public DateTime ActivityPerformedTime { get; set; }

    public virtual UserOrganizationMapping UserOrg { get; set; } = null!;
}
