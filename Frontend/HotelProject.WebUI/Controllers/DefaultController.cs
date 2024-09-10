using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5266/api/Subscribe", stringContent);

            //Mail Gönderme İşlemi
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "furkan.iscn01@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createSubscribeDto.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = "MAİL BÜLTENİ ABONELİK";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Mail Bültenimize abone olduğunuz için teşekkür ediyoruz. Sizi otelimiz ile ilgili kampanyalar ve duyurularla bilgilendireceğiz...\n\n" +
                                   "--\n" +
                                   "HOTELIER\n" +
                                   "hotelierdestek@gmail.com";
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("furkan.iscn01@gmail.com", "rfngwvvenfpeykcd");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return RedirectToAction("Index", "Default");
        }
    }
}
