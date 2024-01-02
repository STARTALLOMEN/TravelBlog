using System.Text;
using API.Data;
using API.Data.Entities;
using API.Data.Seeding;
using API.Mapping;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
services.AddControllers().AddNewtonsoftJson();

services.AddCors(o =>
    o.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod()));

services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

services.AddDbContext<DataContext>();
/////

services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IDestinationRepository, DestinationRepository>();
services.AddScoped<IDestinationService, DestinationService>();
services.AddScoped<IBlogRepository, BlogRepository>();
services.AddScoped<IBlogService, BlogService>();
services.AddScoped<IQuestionRepository, QuestionRepository>();
services.AddScoped<IQuestionService, QuestionService>();
services.AddScoped<IImageShareRepository, ImageShareRepository>();
services.AddScoped<IImageShareService, ImageShareService>();
services.AddScoped<ILocationRepository, LocationRepository>();
services.AddScoped<ILocationService, LocationService>();
services.AddScoped<IReviewDestinationRepository, ReviewDestinationRepository>();
services.AddScoped<IReviewDestinationService, ReviewDestinationService>();
services.AddScoped<IUploadImgService, UploadImgService>();
services.AddAutoMapper(typeof(AutoMappingConfiguration).Assembly);
// services.AddScoped<UserManager<User>, UserManager<User>>();
// services.AddScoped<SignInManager<User>, SignInManager<User>>();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            //ValidIssuer: chua address, host ex: http://localhost:7014
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]))
        };
    });
    //.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Seeding
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
try
{
    var context = serviceProvider.GetService<DataContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
    Seed.SeedRole(context);
}
catch (Exception ex)
{
    var logger = serviceProvider.GetService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
try
{
    var context = serviceProvider.GetService<DataContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
    Seed.SeedTypeDestination(context);
}
catch (Exception ex)
{
    var logger = serviceProvider.GetService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
//
try
{
    var context = serviceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
    Seed.SeedProvice(context);
}
catch (Exception ex)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migration Failed");
}
// try
// {
//     var context = serviceProvider.GetRequiredService<DataContext>();
//     context.Database.Migrate();
//     Seed.SeedDictrict(context);
// }
// catch (Exception ex)
// {
//     var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "Migration Failed");
// }

// try
// {
//     var context = serviceProvider.GetRequiredService<DataContext>();
//     context.Database.Migrate();
//     Seed.SeedWard(context);
// }
// catch (Exception ex)
// {
//     var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "Migration Failed");
// }


app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
