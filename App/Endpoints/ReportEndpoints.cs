using crud_sharp.App.Services;

namespace crud_sharp.App.Endpoints;

public static class ReportEndpoints
{
    public static IEndpointRouteBuilder MapReportEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/report").WithTags("Report");

        group.MapGet("/sample/pdf", () =>
        {
            var bytes = SampleReportService.BuildPdf();
            return Results.File(bytes, "application/pdf", "sample-report.pdf");
        }).WithName("GetSampleReportPdf");

        return app;
    }
}
