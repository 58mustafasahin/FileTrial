using FileWebAPI.Utilities.File;
using FileWebAPI.Utilities.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IPathHelper, PathHelper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger(p =>
        {
            p.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {
                swaggerDoc.Servers = new List<OpenApiServer>
                    {new() {Url = $"http://{"/filetrial"}"}};
            });
        });
app.UseSwaggerUI(c => c.SwaggerEndpoint("/filetrial/swagger/v1/swagger.json", "WebAPI"));


app.UseAuthorization();

app.MapControllers();

app.Run();
