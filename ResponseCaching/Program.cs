var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
config.CacheProfiles.Add("Demo",

new Microsoft.AspNetCore.Mvc.CacheProfile()
{
    Duration= 5,
    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any,
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

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
app.UseResponseCaching();
app.Use(async(context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
    {
        MaxAge = TimeSpan.FromSeconds(5),
        Public = true
    };
   await next();
});

app.Run();
