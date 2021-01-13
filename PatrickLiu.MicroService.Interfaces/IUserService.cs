using PatrickLiu.MicroService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatrickLiu.MicroService.Interfaces
{
    /// <summary>
    /// 用户服务的接口定义。
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 查找指定主键的用户实例对象。
        /// </summary>
        /// <param name="id">用户的主键。</param>
        /// <returns>返回查找到的用户实例对象。</returns>
        User FindUser(int id);

        /// <summary>
        /// 获取所有用户的实例集合。
        /// </summary>
        /// <returns>返回所有的用户实例。</returns>
        IEnumerable<User> UserAll();
    }
}
