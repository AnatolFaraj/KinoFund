using BLL.Collections;
using BLL.Comments;
using BLL.Movies;
using BLL.Users;
using DAL.Repositories;
using Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Files;
using FileServices;

using Core.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using WebAPI.Infrastructure;




namespace WebAPI
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
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<DAL.data.MyContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("KinoFundDB"));

                });

            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<UsersManager>();
            services.AddTransient<MoviesManager>();
            services.AddTransient<CommentsManager>();
            services.AddTransient<CollectionsManager>();
            services.AddTransient<FileService>();
            services.AddTransient<FilesManager>();
            services.AddTransient<UserClaims>();
            services.AddTransient<AuthenticationService>();
            services.AddTransient<JWTTokenService>();
            services.AddHttpContextAccessor();

            var jwtSection = Configuration.GetSection("JWTsettings");
            services.Configure<JWTSettings>(jwtSection);


            var key = Encoding.ASCII.GetBytes(jwtSection.Get<JWTSettings>().SecretKey);

            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };

                });





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
