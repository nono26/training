namespace BankAccountAPI
{
    public class Startup
    {
        public IConfiguration Configuration{get;set;}

        public Startup(IConfiguration config){
            Configuration= config;
        }        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services){

            services.AddControllers();
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo{
                        Title="Bank account API",
                        Version="v1"
                        }
                    );
                }
            );

            BankAccountAPI.PrimaryAdpater.Infrastructure.ConfigureServices.Configure(services, Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        
            app.UseSwagger();
            app.UseSwaggerUI();

            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints=>{
                endpoints.MapControllers();
            });
        }
    }
}