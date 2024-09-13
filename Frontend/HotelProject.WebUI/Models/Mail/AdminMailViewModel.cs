﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Mail
{
    public class AdminMailViewModel
    {
        public string? Name { get; set; }
        public string? SenderMail { get; set; }
        [Required]
        [EmailAddress]
        public string? ReceiverMail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}