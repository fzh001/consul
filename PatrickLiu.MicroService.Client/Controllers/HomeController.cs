using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatrickLiu.MicroService.Client.Models;
using PatrickLiu.MicroService.Interfaces;
using PatrickLiu.MicroService.Models;

namespace PatrickLiu.MicroService.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private static int index;

        /// <summary>
        /// 初始化该类型的新实例。
        /// </summary>
        /// <param name="logger">注入日志对象。</param>
        /// <param name="userService">注入用户服务对象。</param>
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// 首页。
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            #region 通过 Nginx 网关访问服务实例。

            string url = "http://localhost:6400/gate/users/all?Authentication=bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjE3RUI3Q0I1NjBDN0ExODgzOEZEQUJCQTg0NEE0MzU2IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDc2NjkxNzUsImV4cCI6MTYwNzY3Mjc3NSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo3Mjk5IiwiYXVkIjoiVXNlckFwaSIsImNsaWVudF9pZCI6IlBhdHJpY2tMaXUuTWljcm9TZXJ2aWNlLkF1dGhlbnRpY2F0aW9uRGVtbyIsImNsaWVudF9yb2xlIjoiQWRtaW4iLCJjbGllbnRfbmlja25hbWUiOiJQYXRyaWNrTGl1IiwiY2xpZW50X2VNYWlsIjoiUGF0cmlja0xpdUBzaW5hLmNvbSIsImp0aSI6IkM0NTg5QTZBOTYyMkVCQzg5MzkxQ0Q2ODQyQ0NFN0MyIiwiaWF0IjoxNjA3NjY5MTc0LCJzY29wZSI6WyJVc2VyLkdldCJdfQ.XvNWAeVs9tN5e4Jx3o12FbsY74Vk_iWmynh9Ty8Es5Q_FYs2qGy_rAYz1VW-Mec5jh9Dz_i6WLXMG4A6a98ArRQP4ZWR-4V4CZFZdNofUW7H4JjYUIbhBBn4PHRgrRlu99jqXz34b6CqP5Rv8JgA-Yu1nDtdc1gR3OBN4t_bZaTbvaKp6Y_yS2UYC9VmRNWSS_7aELAvgvifaWmpJm55q5H4i0x-zCP-8yBMW_EHBTUfV6i5k0H71jlel-0wWOw6sijjPQMXdyDZyfg6-RJ2naOcGUItsY0LzDiNBRXoF_qDO0jFqq5-pPurwxaG8HnTx0AtcVEe2tpt2GoO_OJS6g";

            #endregion

            string content = InvokeAPI(url);
            this.ViewBag.Users = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<User>>(content);
            Console.WriteLine($"This is {url} Invoke.");


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// 封装 HttpClient 实例，提供 Http 调用。
        /// </summary>
        /// <param name="url">http url 的地址。</param>
        /// <returns>返回结束数据，格式：JSON。</returns>
        public static string InvokeAPI(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri(url);
                var result = client.SendAsync(message).Result;
                string conent = result.Content.ReadAsStringAsync().Result;
                return conent;
            }
        }
    }
}
