using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using RapidApiConsume.Models;
using System.Net.Http;

namespace RapidApiConsume.Controllers
{
    public class NewsController : Controller
    {

        //public async Task<IActionResult> Index()
        //{
        //    //List<ApiNewsViewModel> apiNewsViewModels = new List<ApiNewsViewModel>();
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://api.tmgrup.com.tr/v1/link/352"),
        //    };
        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        //var values2=apiNewsViewModels.ToList();
        //        var values=JsonConvert.DeserializeObject<ApiNewsViewModel.Articles>(body);
        //        return View(values.Response.ToList());
        //    }
        //}
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://api.tmgrup.com.tr/v1/link/352";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // API yanıtını JSON olarak ayrıştırma
                    dynamic apiResponse = JsonConvert.DeserializeObject(responseContent);

                    List<string> titles = new List<string>();
                    foreach (var article in apiResponse.data.articles.Response)
                    {
                        string title = article.Title;
                        titles.Add(title);
                    }

                    string TitleShort = apiResponse.data.articles.Response[5].TitleShort;
                    string primaryImage = apiResponse.data.articles.Response[25].primaryImage;

                    ViewBag.Titles = titles;
                    ViewBag.PrimaryImage = primaryImage;

                }
                else
                {
                    ViewBag.Title = "API isteği başarısız oldu.";
                }
            }

            return View();
        }
    }
}
