using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PatrickLiu.MicroService.Interfaces;
using PatrickLiu.MicroService.ServiceInstance.Utilities;
using PatrickLiu.MicroService.Services;

namespace PatrickLiu.MicroService.ServiceInstance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //�����޹ش���ʡ��

            #region Consul ע��

            string serviceID = $"Service:{Configuration["ip"]}:{Configuration["port"]}---{Guid.NewGuid()}";
            string consuleServiceName = "PatrickLiuService";

            //ע�����
            Configuration.ConsulRegist(consuleServiceName, serviceID);

            //ע������
            applicationLifetime.ConsulDown(serviceID);

            #endregion
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
