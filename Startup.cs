using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Betting.Contexts;
using Betting.ScheduleTask;
using Betting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Betting
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            // services.AddSwaggerGen();

            services.AddDbContext<DataBaseContext>(ServiceLifetime.Transient);
            //services.AddDbContext<DataBaseContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn"))
            //// .LogTo(Console.WriteLine, LogLevel.Information));
            //.LogTo(Console.WriteLine, LogLevel.Information), ServiceLifetime.Transient);
            //services.AddScoped<ISportServices,SportServices>();

            services.AddTransient<ISportServices, SportServices>();
            services.AddSingleton<IHostedService, PullApiCallTask>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.useSwagger();
                //app.useSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
