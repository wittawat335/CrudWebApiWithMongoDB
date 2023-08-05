using Crud.Infrastructure;
using Crud.Core;
using Crud.Core.Model.MongoDB;
using Crud.WebApi;

var builder = WebApplication.CreateBuilder(args);
//   from Infrastructure
builder.Services.InjectDependence(builder.Configuration);

//   from Core
builder.Services.RegisterServices();
builder.Services.MongoDbIdentityConfig(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
