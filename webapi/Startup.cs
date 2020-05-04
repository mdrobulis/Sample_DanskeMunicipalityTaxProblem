using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using service.Services;
using service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

              // recreate and seed the database
              // 

                var InitDataProvider = new FileDataProvider("../init.csv");
                using(var db = new TaxDB()){
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.TaxPeriods.AddRange(InitDataProvider.GetAllTaxRecords());
                db.SaveChanges();
            };
            

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             //services.AddDbContext<TaxDB>(options =>
             //  options.UseSqlite(Configuration.GetConnectionString("MyConnection")));
            services.AddSingleton<IDataProvider,DatabaseDataProvider >();
            services.AddSingleton<ITaxCalculator,PeriodicTaxCalculator>();
            services.AddSingleton<ITaxRecordRepository,NativeTaxRepository>();
            services.AddSingleton<ITimeProvider,UtcTimeProvider>();
            services.AddSingleton<IDataViewMapper,RecordMapper>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
            } else 
            {
                app.UseExceptionHandler("/error");  // Default Exception middleware
                //app.UseExceptionHandler(x=>{});   // Lambda Exception middleware for more control.
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
