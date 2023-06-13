using Microsoft.EntityFrameworkCore;
using porto_back;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PortoDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
