using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using Crud.Domain;
using Autofac;

namespace Crud.API
{
    public class Startup
    {
        const string AllowCrudOrigins = "AllowCrudPolicy";
        public IConfiguration Configuration { get; }
        // public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers()
                .AddXmlSerializerFormatters()
                .AddNewtonsoftJson(JsonSerializer)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<VisitaModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            MigrationStart<CrudContext>(app);
        }

        private void JsonSerializer(MvcNewtonsoftJsonOptions options)
        {
            JsonSerializerSettings settings = options.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.None;
        }

        private void MigrationStart<TContext>(IApplicationBuilder app) where TContext : DbContext
        {
            IServiceScopeFactory scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using IServiceScope serviceScope = scopeFactory.CreateScope();
            TContext context = serviceScope.ServiceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
    }
}
