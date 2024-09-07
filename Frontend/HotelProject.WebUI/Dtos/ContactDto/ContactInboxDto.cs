﻿namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class ContactInboxDto
    {
        public int ContactID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
    }
}
