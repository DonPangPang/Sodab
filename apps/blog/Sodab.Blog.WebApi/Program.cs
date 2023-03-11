using Sodab.Blog.WebApi.Data;
using Sodab.Framework.Common;
using Sodab.Framework.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSodab<SodabBlogDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

var dbContext = ServiceLocator.GetService<SodabBlogDbContext>();

if (await dbContext.Database.CanConnectAsync())
{
    await dbContext.Database.EnsureCreatedAsync();
}