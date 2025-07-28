using Microsoft.EntityFrameworkCore;
using Skill_Hub.Configurations;
using Skill_Hub.Data;
using Skill_Hub.Profiles;
using Skill_Hub.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomServices();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwaggerGen(SwaggerConfiguration.Configure);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(UserMappingProfile), typeof(MappingProfile), typeof(EnrollmentProfile));
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();