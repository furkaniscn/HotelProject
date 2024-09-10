using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SubscribeDto
{
    public class CreateSubscribeDto
    {
        [Required]
        [EmailAddress]
        public string? Mail { get; set; }
    }
}
