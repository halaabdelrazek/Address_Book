using AddressBookBL.ContactBL;
using AddressBookBL.DepartmentBL;
using AddressBookBL.JobTitleBL;
using DataAL.Data.Context;
using DataAL.DatabaseModels;
using DataAL.Repositories.ContactRepository;
using DataAL.Repositories.DepartmentRepository;
using DataAL.Repositories.JobTitleRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowOrigins = "_myAllowcOrigins";




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                          
                          
                          
                      });
});

// Add services to the container.
builder.Services.AddScoped<AddressBookContext, AddressBookContext>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJobTitleRepository, JobTitleRepository>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IJobTitleBL, JobTitleBL>();
builder.Services.AddScoped<IContactBL, ContactBL>();


#region Default 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion




#region Context

var connectionString = builder.Configuration.GetConnectionString("AddressBookConnectionString");
builder.Services.AddDbContext<AddressBookContext>(option =>
option.UseLazyLoadingProxies()
      .UseSqlServer(connectionString));


#endregion

#region ASP Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;


    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
})
    .AddEntityFrameworkStores<AddressBookContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "AddressBook";
    options.DefaultChallengeScheme = "AddressBook";
})
    .AddJwtBearer("AddressBook", options =>
    {
        var secretKey = builder.Configuration.GetValue<string>("SecretKey");
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
        var key = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = true,
            ValidIssuer = "AuthServer1",
            ValidateAudience = true,
            ValidAudience = "Service1"
        };
    });
#endregion



#region RegisteringAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion
# region MiddleWares

var app = builder.Build();

app.UseCors(MyAllowOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion