using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TaskSample.Data;
using TaskSample.Helpers;
using TaskSample.Hubs;
using TaskSample.Services;

namespace TaskSample
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

             services.AddDbContext<AppDbContext>(opt => 
                    opt.UseInMemoryDatabase("InMem"));

            
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>  
            {  
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });  
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme  
                {  
                    Name = "Authorization",  
                    Type = SecuritySchemeType.Http,  
                    Scheme = "basic",  
                    In = ParameterLocation.Header,  
                    Description = "Basic Authorization header using the Bearer scheme."  
                });  
                c.AddSecurityRequirement(new OpenApiSecurityRequirement  
                {  
                    {  
                          new OpenApiSecurityScheme  
                            {  
                                Reference = new OpenApiReference  
                                {  
                                    Type = ReferenceType.SecurityScheme,  
                                    Id = "basic"  
                                }  
                            },  
                            new string[] {}  
                    }  
                });  
            });

            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:6001")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((x) => true)
                            .AllowCredentials();
                    });
            });
            services.AddSignalR();  

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepo, UserRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskSample v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("_myAllowSpecificOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>  
            {  
                 endpoints.MapHub<NotificationHub>("/NotificationHub"); 
            });  
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               
            });
                

        }
    }
}
