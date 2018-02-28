using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using Model.Model.Context;
using Model.Model.Repository;
using Model.Services.Customers;


namespace CustomersApi
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
            services.AddMvc();

            var connection = Configuration.GetConnectionString("AuthentConnection");

            services.AddDbContext<ModelAngularContext>(options => options.UseSqlServer(connection));

            // Add application services.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ICustomerServices, CustomerServices>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ModelAngularContext>()
              .AddDefaultTokenProviders();

            services.AddCors(
           options => options.AddPolicy("AllowCors",
           builder =>
           {
               builder
                              .WithOrigins("http://localhost:56650") //AllowSpecificOrigins;  
                                                                      //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;  
                                                                      //AllowAllOrigins;  
                                                                      //.WithMethods("GET") //AllowSpecificMethods;  
                                                                      //.WithMethods("GET", "PUT") //AllowSpecificMethods;  
                                                                      //.WithMethods("GET", "PUT", "POST") //AllowSpecificMethods;  
                              .WithMethods("GET", "PUT", "POST", "DELETE") //AllowSpecificMethods;  
                                                                           //.AllowAnyMethod() //AllowAllMethods;  
                                                                           //.WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header"); //AllowSpecificHeaders;  
                              .AllowAnyHeader(); //AllowAllHeaders;  
           })
           );

           
            // All the other service configuration.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ModelAngularContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            app.UseCors("AllowCors");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
