namespace NewAccountRegistration.Models
{
    public class MyInfo
    {

        public string SingPassId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Salutation { get; set; }

        public string? Designation { get; set; }

        public string? Email { get; set; }

        public int? OfficeNumber { get; set; }

        public int? MobileNumber { get; set; }

        public bool? AllowNotificationBySms { get; set; }

        public bool? AllowNotificationByEmail { get; set; }

        public string PostalCode { get; set; } = null!;

        public string BuildingName { get; set; } = null!;

        public string StreetName { get; set; } = null!;

        public string HouseNo { get; set; } = null!;

        public string? Country { get; set; }

        public string? LevelNumber { get; set; }

        public string? UnitNumber { get; set; }

        
    }
}