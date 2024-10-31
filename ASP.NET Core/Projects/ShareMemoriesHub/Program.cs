using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLog;
using ShareMemoriesHub.Factory;
using ShareMemoriesHub.Helpers.DBContext;
using ShareMemoriesHub.Helpers.Util;
using ShareMemoriesHub.Interfaces;
using ShareMemoriesHub.Models;
using System.Text;



LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

//CORS Configuration
builder.Services.AddCors(options=>options
                .AddPolicy("CorsPolicy",builder=>builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
                );
//IIS Configuration
builder.Services.AddAuthentication();
builder.Services.Configure<IISOptions>(options => { });
builder.Services.AddScoped<ILoggerUtil, LoggerUtil>();
builder.Services.AddScoped<IMemoryFactory, MemoryFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(configuration.GetConnectionString("ShareMemoriesHubContext")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
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
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    

});


app.Run();
