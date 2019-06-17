using Blog.Logic.Context;
using Blog.Logic.Entities;
using Blog.Logic.Repository;
using Blog.Logic.Repository.Implementation;
using Blog.Service.Implementation;
using Blog.Service.Interfaces;
using Blog.Web.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Blog.Web
{
    class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlogDatabase")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Acc/Login");
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Acc/Login");
            });
            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IRepository<Post>, BaseRepository<Post>>();
            services.AddTransient<BaseRepository<Post>>();
            services.AddTransient<BaseRepository<User>>();
            services.AddTransient<BaseRepository<Comment>>();
            services.AddTransient<DbContext , DataContext>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(),"logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Acc}/{action=Index}");

            });
            /*app.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
                await context.Response.WriteAsync("Hello world");
            });*/
        }
    }
}
