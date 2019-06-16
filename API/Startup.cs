using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Application.Commands;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MyDbContext>();

            services.AddTransient<IGetBrandsCommand,EfGetBrandsCommand>();
            services.AddTransient<IGetBrandCommand, EfGetBrandCommand>();
            services.AddTransient<IAddNewBrandCommand, EfIAddNewBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();

            services.AddTransient<IGetTypesCommand, EfGetTypesCommand>();
            services.AddTransient<IGetTypeCommand, EfGetTypeCommand>();
            services.AddTransient<IAddNewTypeCommand, EfIAddNewTypeCommand>();
            services.AddTransient<IEditTypeCommand, EfEditTypeCommand>();
            services.AddTransient<IDeleteTypeCommand, EfDeleteTypeCommand>();

            services.AddTransient<IGetModelsCommand, EfGetModelsCommand>();
            services.AddTransient<IGetModelCommand, EfGetModelCommand>();
            services.AddTransient<IAddNewModelCommand, EfIAddNewModelCommand>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();

            services.AddTransient<IGetFuelsCommand, EfGetFuelsCommand>();
            services.AddTransient<IGetFuelCommand, EfGetFuelCommand>();
            services.AddTransient<IAddNewFuelTypeCommand, EfIAddNewFuelTypeCommand>();
            services.AddTransient<IEditFuelCommand, EfEditFuelCommand>();
            services.AddTransient<IDeleteFuelCommand, EfDeleteFuelCommand>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My Api",
                    Description = "This is swagger specification"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
