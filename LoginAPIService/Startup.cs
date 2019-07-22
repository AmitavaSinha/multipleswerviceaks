using LoginAPIService.Infrastructure.Filter;
using LoginAPIService.Models.DB;
using LoginAPIService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LoginAPIService
{
    public class Startup
    {
        readonly string ProjectAllowSpecificOrigins = "projectAllowSpecificOrigins";
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<IRAS_UserDBContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices().AddControllersAsServices().AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Login API", Version = "v1" });
            });

            services.AddSingleton<IConfiguration>(Configuration);
                      
            var urls = _config.GetSection("URLs").Get<string[]>();


            services.AddCors(options =>
            {
                options.AddPolicy(ProjectAllowSpecificOrigins,
                //builder => builder.WithOrigins("http://testIRAS.com",
                //                        "http://192.168.0.8:4200",
                //                        "http://localhost:59610",
                //                        "http://localhost:4200")//;//.AllowAnyOrigin()
                //.AllowAnyMethod()
                //.AllowAnyHeader()
                //.AllowCredentials());
                 builder => builder.WithOrigins(urls)//;//.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
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
                app.UseExceptionHandler(
                       new ExceptionHandlerOptions
                       {
                           ExceptionHandler = async context =>
                           {
                               context.Response.ContentType = "text/plain";
                               await context.Response.WriteAsync("Welcome to the error page.");
                           }
                       });
                //  app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Login API V1");
            });
            app.UseHttpsRedirection();
            app.UseCors(ProjectAllowSpecificOrigins);
            app.UseMvc();
            
        }
    }
}
