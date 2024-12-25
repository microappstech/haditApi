using haditApi;
using haditApi.Data;
using haditApi.Models;
using haditApi.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using System;

using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOption => sqlOption.EnableRetryOnFailure(maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),null));
    option.EnableDetailedErrors();
    
});
builder.Services.AddCors(op =>
{
    op.AddPolicy("AngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddScoped<HaditService>();
builder.Services.AddScoped< Security>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
Action initializeAction = () => { SeedData.Initialize(app.Services); };
initializeAction.Invoke();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hadit API v1");
    c.RoutePrefix = string.Empty;
});
app.MapGet("/hadits", new Func<HaditService, object>(haditService =>
{
    Func<object> getResult = () =>
    {
        return haditService.GetHadits();
    };
    return getResult.Invoke();
}));
app.MapGet("/categories", (HaditService haditService) =>
{
    Func<object> fetchCategories = () =>
    {
        Func<object> resultFunc = () => haditService.GetCategories();
        return resultFunc.Invoke();
    };
    return fetchCategories.Invoke();
});
app.MapGet("/categories-hadites", (HaditService haditService) =>
{
    Func<object> fetchCategories = () =>
    {
        Func<object> resultFunc = () => haditService.GetCategoriesXidthHadites();
        return resultFunc.Invoke();
    };
    return fetchCategories.Invoke();
});
app.MapGet("/Hadites-by-category/{ctg}", (HaditService haditService, string ctg) =>
{
    _ = int.TryParse(ctg, out int CategryId);
    var result = haditService.GetHaditsByCategory(CategryId);
    return result;
});

app.MapGet("/search", (HaditService haditService, string s) =>
{
    Func<(HaditService, string), object> searchFunc = tuple =>
    {
        var (service, query) = tuple;
        return service.SearchByContent(query);
    };
    return searchFunc.Invoke((haditService, s));
});
app.MapPost("/hadits", (HaditService haditService, ApiPost<List<Hadit>> data) =>
{
    var res = haditService.PostHadites(data);
    return Results.Ok(res);
});
app.MapPost("/hadit", (HaditService haditService, ApiPost<Hadit> data) =>
{
    var post = new ApiPost<List<Hadit>>() { Data = new List<Hadit> { data.Data }, Key = data.Key };
    var res = haditService.PostHadites(post);
    return Results.Ok(res);
});


app.MapGet("/", () =>
{
    return "hello";
});

app.Run();
