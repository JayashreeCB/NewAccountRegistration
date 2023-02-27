using System;
using System.Collections.Generic;

namespace NewAccountRegistration.Models;

public partial class TblEmployee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? PhoneNumber { get; set; }

    public int? SkillId { get; set; }

    public int? YearsExperience { get; set; }
}
