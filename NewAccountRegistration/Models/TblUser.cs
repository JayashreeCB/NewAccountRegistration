using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Department { get; set; } = null!;
}
