using ApiLogin.Application.DI;
using ApiLogin.Converter;
using ApiLogin.FiltrosExcpetion;
using ApiLogin.Infraestrutura.DI;
using ApiLogin.Middlware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(s=>s.JsonSerializerOptions.Converters.Add( new StringConverter()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(c => c.Filters.Add(new FillterException()));
builder.Services.InjecaoDepedenciaApplication();
builder.Services.InjectInfra(builder.Configuration);

var key = "8ede30b1-e161-45ae-845f-7d93eb57adee";
builder.Services.AddAuthentication(s =>
{
    s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseMiddleware<Midlware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
