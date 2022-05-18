using DataAL.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Default 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


builder.Services.AddScoped<AddressBookContext, AddressBookContext>();

#region Context

var connectionString = builder.Configuration.GetConnectionString("AddressBookConnectionString");
builder.Services.AddDbContext<AddressBookContext>(option =>
option.UseSqlServer(connectionString));

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