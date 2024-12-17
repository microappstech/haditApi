using haditApi;
using haditApi.Data;
using haditApi.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOption => sqlOption.EnableRetryOnFailure(maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),null));
    option.EnableDetailedErrors();
    
});
builder.Services.AddScoped<HaditService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
Action initializeAction = () => { SeedData.Initialize(app.Services); };
initializeAction.Invoke();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hadit API v1");
        c.RoutePrefix = string.Empty;
    });
}
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

app.MapGet("/search", (HaditService haditService, string s) =>
{
    Func<(HaditService, string), object> searchFunc = tuple =>
    {
        var (service, query) = tuple;
        return service.SearchByContent(query);
    };
    return searchFunc.Invoke((haditService, s));
});
app.MapPost("/hadits", (HaditService haditService, List<Hadit> hadits) =>
{
    var res = haditService.PostHadites(hadits);
    return Results.Ok(res);
});
app.MapPost("/hadit", (HaditService haditService, Hadit hadit) =>
{
    var res = haditService.PostHadites(new List<Hadit> { hadit });
    return Results.Ok(res);
});


app.MapGet("/", () =>
{
    return "hello";
});

app.Run();
