using System.Text.Json.Serialization;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using crud_sharp.App.Config;
using crud_sharp.App.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        if (document.Paths is null)
        {
            return Task.CompletedTask;
        }

        foreach (var pathItem in document.Paths.Values)
        {
            if (pathItem?.Operations is null) continue;

            foreach (var operation in pathItem.Operations.Values)
            {
                if (operation?.Parameters is null) continue;

                foreach (var parameter in operation.Parameters)
                {
                    if (parameter is OpenApiParameter p && p.Name is "page" or "pageSize")
                    {
                        p.Required = true;
                    }
                }
            }
        }

        return Task.CompletedTask;
    });
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});
builder.Services.AddAppDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => "OK").WithName("GetHealth");

app.MapEmployeeEndpoints();
app.MapMasterEndpoints();
app.MapReportEndpoints();

app.Run();
