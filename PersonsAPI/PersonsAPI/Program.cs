using Microsoft.EntityFrameworkCore;
using PersonsAPI.Data;
using PersonsAPI.Interfaces;
using PersonsAPI.Repository;
using PersonsAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    if (true)
    {
        endpoints.MapHub<PersonHub>("/personHub");
        endpoints.MapControllers();
    }
});
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
