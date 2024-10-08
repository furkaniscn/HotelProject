﻿using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5266/api/Contact/");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5266/api/Contact/GetContactCount/");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5266/api/SendMessage/GetSendMessageCount/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5266/api/SendMessage/");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5266/api/Contact/GetContactCount/");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5266/api/SendMessage/GetSendMessageCount/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5266/api/Contact/GetContactCount/");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5266/api/SendMessage/GetSendMessageCount/");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.contactCount = jsonData;

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.sendMessageCount = jsonData2;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "furkan.iscn2@hotmail.com";
            createSendMessageDto.SenderName = "Furkan";
            createSendMessageDto.SenderSurname = "İŞCAN";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5266/api/SendMessage/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5266/api/SendMessage/{id}");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5266/api/Contact/GetContactCount/");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5266/api/SendMessage/GetSendMessageCount/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;

                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5266/api/Contact/{id}");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5266/api/Contact/GetContactCount/");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5266/api/SendMessage/GetSendMessageCount/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;

                return View(values);
            }
            return View();
        }
    }
}
