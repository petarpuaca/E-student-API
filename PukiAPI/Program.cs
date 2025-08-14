using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PukiAPI.Data;
using PukiAPI.Mappings;
using PukiAPI.Repositories;
using AutoMapper;
using PukiAPI.Repositories.ProfesorRepo;
using PukiAPI.Repositories.PredmetRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PukiAPI.Repositories.TokenRepo;
using PukiAPI.Repositories.StudentPredmetRepository;
using PukiAPI.Repositories.ProfesorPredmetRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PUKIDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("PukiAPIConnectionString")));
builder.Services.AddDbContext<PUKIAuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PukiAPIAuthConnection")));
builder.Services.AddScoped<IStudentRepository,SQLStudentRepository>();
builder.Services.AddScoped<IProfesorRepo, SQLProfesor>();
builder.Services.AddScoped<IPredmetRepo, SQLPredmet>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IStudentPredmetRepo,SQLStudentPredmet>();
builder.Services.AddScoped<IProfesorPredmetRepo,SQLProfesorPredmet>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("PukiAPI")
    .AddEntityFrameworkStores<PUKIAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
 options.Password.RequireDigit = false;
 options.Password.RequireLowercase = false;
 options.Password.RequireNonAlphanumeric=false;
 options.Password.RequireUppercase = false;
 //options.Password.RequiredLength = 6;
 //options.Password.RequiredUniqueChars = 1;

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>options.TokenValidationParameters= new TokenValidationParameters
{
    ValidateIssuer= true,
    ValidateAudience= true,
    ValidateLifetime= true,
    ValidateIssuerSigningKey= true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") // DODAJ SVE PORTOVE SA KOJIH POKRE?EŠ FRONTEND
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
