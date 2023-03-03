﻿namespace NewAccountRegistration.DataTransferModel
{
    public class GetAddressDto
    {
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public int BlockNumber { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public int LevelNumber { get; set; }
        public int UnitNumber { get; set; }
    }
}
