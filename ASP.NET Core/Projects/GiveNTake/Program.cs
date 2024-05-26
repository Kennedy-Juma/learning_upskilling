using GiveNTake.Model;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddDbContext<GiveNTakeContext>(options=> options.UseSqlServer(configuration.GetConnectionString("GiveNTakeDB")));

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
