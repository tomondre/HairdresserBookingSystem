using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using API.Model.Appointments;
using API.Model.CompanyOwners;
using API.Model.Customers;
using API.Model.Products;
using API.Model.WorkingDays;
using API.Models;
using API.Persistence;
using API.Persistence.Appointments;
using API.Persistence.CompanyOwners;
using API.Persistence.Customers;
using API.Persistence.WorkingDays;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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
            services.AddSingleton<IUserDao, UserDao>();
            services.AddSingleton<IUserModel, UserModel>();

            services.AddSingleton<ICompanyDao, CompanyDao>();
            services.AddSingleton<ICompanyModel, CompanyModel>();

            services.AddSingleton<IProductDao, ProductDao>();
            services.AddSingleton<IProductModel, ProductModel>();

            services.AddSingleton<IWorkingDayDao, WorkingDayDao>();
            services.AddSingleton<IWorkingDayModel, WorkingDayModel>();

            services.AddSingleton<IAppointmentDao, AppointmentDao>();
            services.AddSingleton<IAppointmentModel, AppointmentModel>();

            services.AddSingleton<ICustomerDao, CustomerDao>();
            services.AddSingleton<ICustomerModel, CustomerModel>();

            services.AddSingleton<ICompanyOwnerDao, CompanyOwnerDao>();
            services.AddSingleton<ICompanyOwnerModel, CompanyOwnerModel>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
