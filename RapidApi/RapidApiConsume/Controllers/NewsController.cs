using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using RapidApiConsume.Models;
using System.Net.Http;

namespace RapidApiConsume.Controllers
{
    public class NewsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.tmgrup.com.tr/v1/link/352"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiNewsViewModel>(body);
                var values1 = values.data.articles.Response;
                //A1-2 için
                ViewBag.image = values1[0].primaryImage;
                ViewBag.titleShort = values1[0].TitleShort;
                ViewBag.title = values1[0].Title;
                ViewBag.url = values1[0].Url;
                //B3 için
                ViewBag.sImage1 = values1[1].secondaryImage;
                ViewBag.url1 = values1[1].Url;
                ViewBag.sImage2 = values1[2].secondaryImage;
                ViewBag.url2 = values1[2].Url;
                //C4-1 için -primaryimage ve titleshort
                ViewBag.pImage = values1[3].primaryImage;
                ViewBag.tShort = values1[3].TitleShort;
                ViewBag.url3 = values1[3].Url;
                //C4-2 için -primaryimage ve titleshort
                ViewBag.pImage1 = values1[4].primaryImage;
                ViewBag.tShort1 = values1[4].TitleShort;
                ViewBag.url4 = values1[4].Url;
                //C4-3 için -primaryimage ve titleshort
                ViewBag.pImage2 = values1[5].primaryImage;
                ViewBag.tShort2 = values1[5].TitleShort;
                ViewBag.url5 = values1[5].Url;
                //C4-4 için -primaryimage ve titleshort
                ViewBag.pImage3 = values1[6].primaryImage;
                ViewBag.tShort3 = values1[6].TitleShort;
                ViewBag.url6 = values1[6].Url;
                //D5 için-title
                ViewBag.titled1 = values1[7].Title;
                ViewBag.titled2 = values1[8].Title;
                ViewBag.titled3 = values1[9].Title;
                //D6 için-spot
                ViewBag.spot1 = values1[10].Spot;
                ViewBag.spot2 = values1[11].Spot;
                ViewBag.spot3 = values1[12].Spot;
                //F10-1 için
                ViewBag.secImagef1 = values1[7].secondaryImage;
                ViewBag.urlf1 = values1[7].Url;
                //F10-2 için
                ViewBag.secImagef2 = values1[8].secondaryImage;
                ViewBag.urlf2 = values1[8].Url;
                //F10-3 için
                ViewBag.secImagef3 = values1[9].secondaryImage;
                ViewBag.urlf3 = values1[9].Url;
                //F10-4 için
                ViewBag.secImagef4 = values1[10].secondaryImage;
                ViewBag.urlf4 = values1[10].Url;
                //F10-5 için
                ViewBag.secImagef5 = values1[11].secondaryImage;
                ViewBag.urlf5 = values1[11].Url;
                //F10-6 için
                ViewBag.secImagef6 = values1[12].secondaryImage;
                ViewBag.urlf6 = values1[12].Url;
                //F10-7 için
                ViewBag.secImagef7 = values1[13].secondaryImage;
                ViewBag.urlf7 = values1[13].Url;
                //F10-8 için
                ViewBag.secImagef8 = values1[14].secondaryImage;
                ViewBag.urlf8 = values1[14].Url;
            }
            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.tmgrup.com.tr/v1/link/424"),
            };
            using (var response1 = await client1.SendAsync(request1))
            {
                response1.EnsureSuccessStatusCode();
                var body1 = await response1.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ApiVideoViewModel>(body1);
                var values3 = values2.data.videos.Response;
                //E7 için player
                ViewBag.videoImage = values3[0].primaryImage;
                ViewBag.player = values3[0].VideoUrl;
                //E7a için date
                string datetime = values3[0].OutputDate;
                // Boşluk karakterine göre ayırma
                string[] first = datetime.Split(' ');
                string date = first[1];
                string time = first[2];
                ViewBag.date = date;
                ViewBag.time = time;
                //E8 için titleshort
                ViewBag.tShortE8 = values3[0].TitleShort;
                ViewBag.titleE8 = values3[0].Title;
                //E9 için spot       
                ViewBag.spote9 = values3[0].Spot;
            }
            return View();
        }
    }
}
