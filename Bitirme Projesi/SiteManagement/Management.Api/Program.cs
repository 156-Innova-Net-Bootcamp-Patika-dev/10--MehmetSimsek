using EventBus.Messages.Commons;
using Management.Api.Extensions;
using Management.Application.Extensions;
using Management.Application.Mappings;
using Management.Application.Settings;
using Management.Domain.Entities.Authentications;
using Management.Infrastructure.Contracts.Persistance;
using Management.Infrastructure.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Extensions
builder.Services.AddInfrastructureService(builder.Configuration);


builder.Services.AddApplicationService();
#endregion
#region Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));
var jwt = builder.Configuration.GetSection("JWT").Get<JwtSettings>();

#endregion
#region Password Settings
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
#endregion
#region Service Extensions
builder.Services.ConfigureCors();
#endregion



#region AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion

builder.Services.AddSingleton<JwtSettings>();
builder.Services.AddControllers();
#region AuthExtensions
builder.Services.AddAuth(jwt);
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
#region Swagger 
string version = "v1";
builder.Services.AddSwaggerGen(gen =>
{
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Jwt Bearer Token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        },
    };

    gen.SwaggerDoc(version, new OpenApiInfo
    {
        Title = "Site Management Wep Api",
        Version = version,
        License = new OpenApiLicense
        {
            Name = "Powered by Want2Work",
            Url = new Uri("https://wantowork.de/"),
        },
        Contact = new OpenApiContact
        {
            Name = "Erdi Demir",
            Email = "erdi.demir@erdidemir.com.tr"
        }
    });

    gen.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    gen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
    gen.UseAllOfToExtendReferenceSchemas();
   
    });




#endregion

var app = builder.Build();
#region HostExtensions
app.MigrateDatabase<ApplicationContext>((context, builder) =>
{
    var logger = builder.GetService<ILogger<ApplicationContextSeed>>();
    ApplicationContextSeed.SendAsync(context, logger).Wait();
});
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


#region AuthExtensions
app.UseAuth();
#endregion

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
