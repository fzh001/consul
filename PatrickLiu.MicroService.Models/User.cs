using System;
using System.Collections.Generic;
using System.Text;

namespace PatrickLiu.MicroService.Models
{
    /// <summary>
    /// 用户模型。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 获取或者设置用户主键。
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 获取或者设置用户姓名。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或者设置用户账号名称。
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 获取或者设置用户密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或者设置用户的电子邮箱地址。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或者设置用户角色。
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 获取或者设置用户的登录时间。
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}
