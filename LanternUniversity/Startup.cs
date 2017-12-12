using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanternUniversity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LanternUniversity
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
            services.AddSingleton<IRepository<Student>, InMemoryRepository<Student>>();
            services.AddSingleton<IRepository<Subject>, InMemoryRepository<Subject>>();
            services.AddSingleton<IRepository<Lecture>, InMemoryRepository<Lecture>>();
            services.AddSingleton<IRepository<LectureTheatre>, InMemoryRepository<LectureTheatre>>();
            
            services.AddMvc();
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
