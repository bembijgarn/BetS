using BSMVCprj.Helper;
using BSMVCprj.Interfaces;
using BSMVCprj.Repository;
using BSMVCprj.Repository.API;
using BSMVCprj.Repository.token;
using BSMVCprj.Services;
using BSMVCprj.Services.API;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSMVCprj
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
            services.AddAuthentication("BScookie").AddCookie("BScookie", options =>
            {
                options.Cookie.Name = "BScookie";
                options.LoginPath = "/LoginRegistration/Login";
            });


            services.AddControllersWithViews();
            services.AddScoped<IallUserAccount, UserAccount>();
            services.AddScoped<ILoginRegistrationStatus, LoginRegistrationStatus>();
            services.AddScoped<IMoneyTransfer, TransferMoney>();
            services.AddScoped<ItransactionLOG, TrasactionLog>();
            services.AddScoped<IallTransaction, Transactionstory>();
            services.AddScoped<IDetails, Details>();
            services.AddScoped<IEdit, Edit>();
            services.AddScoped<IGamble, GambleSRVC>();
            services.AddScoped<IBankRequest, BankRequest>();
            services.AddScoped<IBanktransferrequest, Banktransferrequest>();
            services.AddScoped<IBalance, Balancerep>();
            services.AddScoped<Irst, Rest>();
            services.AddScoped<IToken, TokenService>();
            services.AddScoped<IAPIBALANCE, BALANCEservice>();
            services.AddScoped<IAPIUSER, APIUSERservice>();
            services.AddScoped<IAUTH, AUTHservice>();
            services.AddScoped<IBETT, BETTservice>();
            services.AddScoped<IWINN, IWINNservice>();
            services.AddScoped<ICANCELBETT, CANCELBETTservice>();
            services.AddScoped<ICHANGEWINN, CHANGEWINNservice>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
