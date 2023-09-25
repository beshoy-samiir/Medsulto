using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Eva_project.BaseService;
using Eva_project.BussinessService;
using Eva_project.Configurations;
using Eva_project.Models;
using Eva_project.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Eva_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET Web API",
                    Description = " Eva project"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
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
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr1")));


            builder.Services.AddIdentity<User, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;
                }
                ).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme =
                    JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:Issues"],
                    ValidAudience = builder.Configuration["JWT:Audiance"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddCors(options =>
              options.AddPolicy("mypolicy", policy =>
                  policy.WithOrigins("http://127.0.0.1:60649")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()
                  ));

            builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseBusinessService, CourseBusinessService>();

            builder.Services.AddAutoMapper(typeof(MapperConfig));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("mypolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}