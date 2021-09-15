using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NotaMarket.Api.Extensions;
using NotaMarket.Api.Extensions.Exceptions;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.Composer;
using NotaMarket.Api.Model.SheetMusic;
using NotaMarket.Api.Model.Instrument;
using NotaMarket.Api.Model.InstrumentType;
using NotaMarket.Api.Validation;
using NotaMarket.Business.Abstract;
using NotaMarket.Business.Concrete;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.DataAccess.Concrete;
using NotaMarket.DataAccess.Context;
using NotaMarket.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Api
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
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nota Market API",
                    Description = ""
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddDbContext<ApplicationDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            services.AddScoped<IInstrumentDal, InstrumentDal>();
            services.AddScoped<IInstrumentTypeDal, InstrumentTypeDal>();
            services.AddScoped<IComposerDal, ComposerDal>();
            services.AddScoped<ISheetMusicDal, SheetMusicDal>();


            services.AddScoped<IInstrumentService, InstrumentManager>();
            services.AddScoped<IInstrumentTypeService, InstrumentTypeManager>();
            services.AddScoped<IComposerService, ComposerManager>();
            services.AddScoped<ISheetMusicService, SheetMusicManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
              options.SaveToken = true;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateIssuerSigningKey = true,
                  ValidAudience = Configuration["JWT:ValidAudience"],
                  ValidIssuer = Configuration["JWT:ValidIssuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
              };
            });


            services.AddMvc()
                .AddJsonOptions(i=> 
                {
                    i.JsonSerializerOptions.PropertyNamingPolicy = null;
                    i.JsonSerializerOptions.DictionaryKeyPolicy = null;
                    i.JsonSerializerOptions.WriteIndented = true;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = c =>
                    {
                        var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
                          .SelectMany(v => v.Errors)
                          .Select(v => v.ErrorMessage));

                        return new BadRequestObjectResult(new ResponseObjectModel<string>
                        {
                            Success = false,
                            StatusCode=400,
                            Message = errors,
                            Response=null
                        });
                    };
                })
                .AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            services.AddAuthentication();


            services.AddTransient<IValidator<CreateInstrumentModel>, InstrumentValidator>();
            services.AddTransient<IValidator<CreateInstrumentTypeModel>, InstrumentTypeValidator>();
            services.AddTransient<IValidator<ComposerModel>, ComposerValidator>();
            services.AddTransient<IValidator<CreateSheetMusicModel>, SheetMusicValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nota Market V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
