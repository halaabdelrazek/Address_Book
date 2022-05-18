using AddressBookBL.DepartmentBL;
using AddressBookBL.JobTitleBL;
using DataAL.Data.Context;
using DataAL.Repositories.ContactRepository;
using DataAL.Repositories.DepartmentRepository;
using DataAL.Repositories.JobTitleRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<AddressBookContext, AddressBookContext>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJobTitleRepository, JobTitleRepository>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IJobTitleBL, JobTitleBL>();


#region Default 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion




#region Context

var connectionString = builder.Configuration.GetConnectionString("AddressBookConnectionString");
builder.Services.AddDbContext<AddressBookContext>(option =>
option.UseSqlServer(connectionString));

#endregion





#region RegisteringAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion
# region MiddleWares

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion