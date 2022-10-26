using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddHttpClient("OrderApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7263/");
});
builder.Services.AddHttpClient("CatalogApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7157/");
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer("GatewayAuthenticationKey", option =>
//    {
//        option.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Jwt:Issuer"],
//            ValidAudience = builder.Configuration["Jwt:Aud"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//        };
//    });

//builder.Services.AddAuthorization();
//builder.Configuration.AddJsonFile("ocelot.json");
//builder.Services.AddOcelot();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseOcelot().Wait();
app.MapControllers();
app.Run();
