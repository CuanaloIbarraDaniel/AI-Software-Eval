using back_end.Repositories.Implementations;
using back_end.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace back_end
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var Builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json", false, true).AddEnvironmentVariables();
            Configuration = Builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // (RECA / JSCO) Sets the response caching and json configuration
            services.AddMvc(Options =>
            {
                Options.MaxModelValidationErrors = 50;
            }).AddControllersAsServices().ConfigureApiBehaviorOptions(Options =>
            {
                Options.SuppressModelStateInvalidFilter = true;
            });
            // (REPOSITORY) Joins the given interface with the implementation. When app ask for an interace give it a implementation
            services.AddScoped<IOrderInterface, OrderImplementation>();
            services.AddScoped<IProductInterface, ProductImplementation>();
            // (SWAGGER) Swagger documentation generation settings
            services.AddSwaggerGen(configuration =>
            {
                // Provide Global API Metadata
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AI Softwar Api Documentation",
                    Version = "v1",
                    Description = "AI Software Web Api Documentation for "
                });
                // Configure Swashbuckle to incorporate the XML comments on file into the generated Swagger JSON
                configuration.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), "AISoftwareDocumentation.xml"));
                // Enable annotations within in the Swagger config block.
                configuration.EnableAnnotations();
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // (SWAGGER) Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                // (SWAGGER) specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(configuration =>
                {
                    // Boolean=false OR String. If set, enables filtering. The top bar will show an edit box that you can use to filter the 
                    // tagged operations that are shown. Can be Boolean to enable or disable, or a string, in which case filtering will be 
                    // enabled using that string as the filter expression. Filtering is case sensitive matching the filter expression anywhere 
                    // inside the tag.
                    configuration.EnableFilter();
                    // Boolean=false. Controls the display of the request duration (in milliseconds) for Try-It-Out requests.
                    configuration.DisplayRequestDuration();
                    // Boolean=false. Controls the display of vendor extension (x-) fields and values for Operations, Parameters, and Schema.
                    configuration.ShowExtensions();
                    // Sets the document title
                    configuration.DocumentTitle = "AI Software Documentation";
                    // Creates the Swagger endpoint for obtaining the swagger.json file
                    configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "AI Software Api Documentation");
                    // Prefix for the swagger documentation
                    configuration.RoutePrefix = "swagger";
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // Static file activation
            app.UseStaticFiles();
            // Where to send the data
            app.UseRouting();
            // Endpoint configuration
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
