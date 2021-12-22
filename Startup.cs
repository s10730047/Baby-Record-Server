using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BabyRecords_Server.core.tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;
using BabyRecords_Server.core.users.Services;
using BabyRecords_Server.features.Babyinfo.Services;
using BabyRecords_Server.features.BabyRecordDiaper.Services;
using BabyRecords_Server.features.BabyRecordBathe.Services;
using BabyRecords_Server.features.BabyRecordFeeding.Services;
using BabyRecords_Server.features.BabyRecordGrowing.Services;
using BabyRecords_Server.features.BabyRecordHealth.Services;
using BabyRecords_Server.features.BabyRecordMilking.Services;
using BabyRecords_Server.features.BabyRecordSleep.Services;
using BabyRecords_Server.features.BabyRecordTemp.Services;
using BabyRecords_Server.features.FamilyGroup.Services;
using BabyRecords_Server.features.tempandhumidity.Services;
using BabyRecords_Server.features.BabyArea.Services;
using BabyRecords_Server.features.BabyFaceCover.Services;


namespace BabyRecords_Server
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
            services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BabyRecord")));
            services.AddControllers();
            services.AddScoped<Cryptography>();
            services.AddScoped<usersServices>();
            services.AddScoped<baby_InfoService>();
            services.AddScoped<Baby_Record_BatheService>();
            services.AddScoped<Baby_Record_DiaperService>();
            services.AddScoped<Baby_Record_FeedingServices>();
            services.AddScoped<Baby_Record_GrowingService>();
            services.AddScoped<Baby_Record_HealthService>();
            services.AddScoped<Baby_Record_MilkingService>();
            services.AddScoped<Baby_Record_SleepService>();
            services.AddScoped<Baby_Record_TempService>();
            services.AddScoped<Family_GroupService>();
            services.AddScoped<Baby_AreaServices>();
            services.AddScoped<Baby_FaceCoverService>();

            services.AddScoped<Jwt>();
            services.AddHttpContextAccessor();

            //services.AddIdentity();
            services.AddAuthentication();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = false,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:KEY"]))
                    };
                });

            //所有API需驗證
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new AuthorizeFilter());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
