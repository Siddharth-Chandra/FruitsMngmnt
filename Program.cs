using FruitsManagementAPI.Services;
using FruitsManagementAPI.Settings;
using Google.Api;
using Google.Cloud.Firestore;
using System.Text.Json;
using static FruitsManagementAPI.Services.IFirestoreProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var firebaseSettings = new FirebaseSettings();
var firebaseJson = JsonSerializer.Serialize(new FirebaseSettings());

builder.Services.AddTransient<IAPIService, APIService>();


builder.Services.AddSingleton<IFirestoreProvider, FirestoreProvider>(_ => new FirestoreProvider(
    new FirestoreDbBuilder
    {
        ProjectId = firebaseSettings.ProjectId,
        JsonCredentials = firebaseJson
    }.Build()
));
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
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
