using Data.AppContext;
using Data.DataConfig;
using MyApi.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.FilterModel;
using Models.Model;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

var SQLConnection = builder.Configuration.GetConnectionString("SQLConnection");
services.AddDbContext<AppDbContext>(db => db.UseSqlServer(SQLConnection));

var PortfolioConnection = builder.Configuration.GetConnectionString("PortfolioConnection");
services.AddDbContext<PortfolioDbContext>(db => db.UseSqlServer(PortfolioConnection));

//Add Identity
services.AddIdentity<ApplicationUser, ApplicationRole>(ad =>
{
    ad.Password.RequiredLength = 5;
    ad.Password.RequireDigit = true;
    ad.Password.RequireLowercase = true;
    ad.SignIn.RequireConfirmedEmail = true;
    ad.User.RequireUniqueEmail = true;

})
.AddDefaultTokenProviders()
.AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmtion")
.AddTokenProvider<ResetPasswordTokenProvider<ApplicationUser>>("resetpassword")
.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//AddAuthentication
services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jb =>
{
    jb.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constrant.Authenticatekey)),
        ValidateIssuer = true,
        ValidIssuer = Constrant.AuthenticateIssuer,
        ValidAudience = Constrant.AuthenticateAudience,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
    };
});

//App Services
services.AddAppServices();



services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new FilterModelBinderProvider());
    //options.Filters.Add(typeof(Authorization));
}).AddNewtonsoftJson(opts => {
    opts.SerializerSettings.ContractResolver = new DefaultContractResolver();
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}).AddJsonOptions(opt =>
    opt.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Cors
var MyCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCorsPolicy, builder => {
        builder.WithOrigins("https://localhost:7083").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/exception");

app.UseHttpsRedirection();

app.UseCors(MyCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
