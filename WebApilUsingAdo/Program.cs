using WebApilUsingAdo.Data_Access_Layer.Interface;
using WebApilUsingAdo.Data_Access_Layer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeDAL, EmployeeDAL>(provider =>
{
    var configuration = provider.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("Dbconnection");
    return new EmployeeDAL(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
