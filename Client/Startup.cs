using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models;
using Client.Data;
using Client.Data.Appointments;
using Client.Data.Authentication;
using Client.Data.Caches;
using Client.Data.Companies;
using Client.Data.CompanyOwners;
using Client.Data.Customers;
using Client.Data.Users;
using Client.Data.WorkingDays;
using Client.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using Shared.Models;

namespace Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            
            services.AddScoped<NotificationService>();
            services.AddScoped<DialogService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddScoped<IWorkingDayService, WorkingDayService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyOwnerService, CompanyOwnerService>();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CompanyOwner", a => a.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "CompanyOwner"));
                options.AddPolicy("Customer", a => a.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "Customer"));
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}