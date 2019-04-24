using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayForUs.Core.Interfaces;
using PayForUs.Core.Models;
using PayForUs.Core.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace PayForUs.Core
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
            services.AddDbContext<PayforusContext>(options => options.UseInMemoryDatabase("payforusDb"));

            services.AddTransient<ClientRepository>();
            services.AddTransient<StatusRepository>();

            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc();
            services.AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true; 
                options.RespectBrowserAcceptHeader = true; 
            })
            .AddFormatterMappings()
            .AddJsonFormatters();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info { Title = "Pay For You", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env
            ,
                                ClientRepository clientSeeder,
                                StatusRepository statusSeeder
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvc();

            clientSeeder.Seed().Wait();
            statusSeeder.Seed().Wait();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pay For Us V1");
            });
        }
    }
}
