using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PatrickLiu.MicroService.ServiceInstance.Controllers
{
    /// <summary>
    /// 健康检查的控制器。
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private IConfiguration _configuration;

        /// <summary>
        /// 初始化该类型的新实例。
        /// </summary>
        /// <param name="configuration">配置接口。</param>
        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 要调用的接口。
        /// </summary>
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            Console.WriteLine($"This is HealhController {_configuration["port"]} Invoke");
            return Ok();
        }
    }
}