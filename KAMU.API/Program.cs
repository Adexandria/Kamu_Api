using KAMU.API.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.ExtractAppConfigurations();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.SetUpDependencies(appSettings);
builder.Services.AddSecurityConfiguration(appSettings.TokenSecret);
builder.Services.SwaggerConfiguration();
builder.Services.SeedDatabase();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
