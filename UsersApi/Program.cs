using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsersApi.Config;
using UsersApi.Data;
using UsersApi.Interfaces.Services;
using UsersApi.Model;
using UsersApi.Services;

var builder = WebApplication.CreateBuilder(args);

#region Services
// Controllers
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<UserDbContext>
    (options =>
    {
        var connectionString = builder.Configuration["ConnectionStrings:UserConnection"];
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

// Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.ConfigureIdentityOptions();
})
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

// Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// JWT
builder.Services.Configure<JwtConfiguration>(
    builder.Configuration.GetSection("JwtSettings"));

// Authorization
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureAuthorization();

// Services Collection
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ConfigureCookies();
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
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
