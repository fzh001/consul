using IdentityServer4.Models;
using System.Collections.Generic;

namespace PatrickLiu.MicroService.AuthenticationCenter
{
    /// <summary>
    /// 自定义的配置文件。
    /// </summary>
    public class ClientInitConfig
    {
        /// <summary>
        /// 获取资源的使用范围。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                //User API
                new ApiScope(name: "User.Get",   displayName: "获取用户数据"),

                // Health API
                new ApiScope(name: "Health.Check",    displayName: "健康检查."),
            };
        }

        /// <summary>
        /// 获取能访问的资源。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("UserApi","Invoice API")
                {
                    Scopes={ "User.Get", "Health.Check" }
                }
            };
        }


        /// <summary>
        /// 客户端的认证条件。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client{
                 ClientId="PatrickLiu.MicroService.AuthenticationDemo",
                 ClientSecrets={new Secret("PatrickLiu123456".Sha256()) },
                 AllowedGrantTypes=GrantTypes.ClientCredentials,
                 AllowedScopes=new[]{ "User.Get", "Health.Check" },
                 Claims=new List<ClientClaim>(){
                 new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                 new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"PatrickLiu"),
                 new ClientClaim("eMail","PatrickLiu@sina.com")
                 }
                }
            };
        }
    }
}