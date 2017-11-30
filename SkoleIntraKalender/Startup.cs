using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkoleIntraKalender.Models;
using System.Net.Http;

namespace SkoleIntraKalender
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
            services.AddMvc(o =>
            {
                o.OutputFormatters.Insert(0, new CalendarOutputFormatter(new CalendarConverter()));
            });

            services.Configure<MvcOptions>(o =>
            {
                o.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddOptions();
            services.Configure<CalendarOptions>(Configuration.GetSection("CalendarService"));

            services.AddScoped<DelegatingHandler, AuthorizedHandler>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<ICalendarConverter, CalendarConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
