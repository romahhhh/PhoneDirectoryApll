using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositoryLayer;
using RepositoryLayer.Respository.Abstraction;
using RepositoryLayer.Respository.Implementation;
using ServicesLayer.Abstraction;
using ServicesLayer.Implementation;
namespace PhoneDirectoryApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phone Directory with OnionArchitecture ", Version = "v1" });
            });

            //#region Connection String  
            //services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            //#endregion

            #region Services Injected  
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IWorkersService, WorkersService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddSingleton<IDatabase, Database>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IWorkersRepository, WorkersRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phone Directory with OnionArchitecture v1"));
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
