using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();//Akışı oluşturduk.
            await file.CopyToAsync(stream);//Dosyayı kopyaladık.
            var bytes = stream.ToArray();//Akıştaki dosyayı byte olarak tutuyoruz.

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:5266/api/FileImage/", multipartFormDataContent);

            return View();
        }
    }
}
