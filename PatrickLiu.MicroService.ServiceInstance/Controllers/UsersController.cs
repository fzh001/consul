using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PatrickLiu.MicroService.Interfaces;
using PatrickLiu.MicroService.Models;

namespace PatrickLiu.MicroService.ServiceInstance.Controllers
{
    /// <summary>
    /// 用户的 API 类型。
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region 私有字段

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化该类型的新实例。
        /// </summary>
        /// <param name="logger">日志记录器。</param>
        /// <param name="userService">用户服务接口。</param>
        /// <param name="configuration">配置服务。</param>
        public UsersController(ILogger<UsersController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        #endregion

        #region 实例方法

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public User Get(int id)
        {
            return _userService.FindUser(id);
        }

        /// <summary>
        /// 获取所有记录。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        [Authorize]
        public IEnumerable<User> Get()
        {
            Console.WriteLine($"This is UsersController {this._configuration["port"]} Invoke");

            return this._userService.UserAll().Select((user => new User
            {
                ID = user.ID,
                Name = user.Name,
                Account = user.Account,
                Password = user.Password,
                Email = user.Email,
                Role = $"{this._configuration["ip"]}：{this._configuration["port"]}",
                LoginTime = user.LoginTime
            })); ;
        }

        /// <summary>
        /// 超时处理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Timeout")]
        public IEnumerable<User> Timeout()
        {
            Console.WriteLine($"This is Timeout Start");
            //超时设置。
            Thread.Sleep(3000);

            Console.WriteLine($"This is Timeout End");

            return this._userService.UserAll().Select((user => new User
            {
                ID = user.ID,
                Name = user.Name,
                Account = user.Account,
                Password = user.Password,
                Email = user.Email,
                Role = $"{this._configuration["ip"]}：{this._configuration["port"]}",
                LoginTime = user.LoginTime
            })); ;
        }

        #endregion
    }
}