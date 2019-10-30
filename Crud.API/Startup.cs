using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpsPolicy;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Crud.Domain;

namespace Crud.API
{
    public class Startup
    {
        const string AllowCrudOrigins = "AllowCrudPolicy";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddXmlSerializerFormatters()
                .AddJsonOptions(JsonSerializer)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connectionString = Configuration.GetConnectionString("CrudConnection");
            DataDirectoryConfig.SetDataDirectoryPath(ref connectionString);

            services.AddDbContext<CrudContext>(options => options.UseSqlServer(connectionString));

            MapperConfiguration mapperConfiguration = MapperStart.Start();
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors(options =>
            {
                options.AddPolicy(AllowCrudOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:11500",
                                        "https://localhost:11500")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .WithHeaders(HeaderNames.Origin,
                                     HeaderNames.ContentType,
                                     HeaderNames.Accept);
                });
            });

            AutofacServiceProvider serviceProvider = AutofacProvider.Provider(services);

            return serviceProvider;
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
                app.UseHsts();
            }
            app.UseCors(AllowCrudOrigins);
            // app.UseHttpsRedirection();
            app.UseMvc();
            StartMigrations<CrudContext>(app);
        }

        private void JsonSerializer(MvcJsonOptions options)
        {
            JsonSerializerSettings serializer = options.SerializerSettings;
            serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.Formatting = Formatting.None;
        }

        private void StartMigrations<TContext>(IApplicationBuilder app) where TContext : DbContext
        {
            IServiceScopeFactory scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using (IServiceScope serviceScope = scopeFactory.CreateScope())
            {
                TContext context = serviceScope.ServiceProvider.GetRequiredService<TContext>();
                context.Database.Migrate();
            }
        }
    }
}
