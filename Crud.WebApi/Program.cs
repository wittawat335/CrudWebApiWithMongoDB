using Crud.Infrastructure;
using Crud.Core;
using Crud.Core.Model.MongoDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSetting")); //Setting MongoDB
builder.Services.InjectDependence(builder.Configuration); // Infrastructure Config
builder.Services.RegisterServices(); //Core Config

builder.Services.AddControllers();
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
