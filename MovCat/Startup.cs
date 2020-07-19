using MovCat.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace MovCat
{
    public class Startup
    {

        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AccountContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AccountContext>();
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                 //      name: "default",
                 //      pattern: "{controller=Account}/{action=Register}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
