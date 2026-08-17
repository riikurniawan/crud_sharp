using ClosedXML.Excel;
using crud_sharp.App.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace crud_sharp.App.Services;

public static class EmployeeExportService
{
    public const string ExcelContentType =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    public static byte[] BuildExcel(List<EmployeeResponse> employees)
    {
        using var workbook = new XLWorkbook();
        var sheet = workbook.AddWorksheet("Employees");

        string[] headers =
        [
            "ID", "Badge No", "Name", "Company", "Project Code", "Project Name",
            "Dept", "Designation", "Status", "Created Date"
        ];

        for (var i = 0; i < headers.Length; i++)
        {
            sheet.Cell(1, i + 1).Value = headers[i];
        }

        for (var r = 0; r < employees.Count; r++)
        {
            var e = employees[r];
            var row = r + 2;

            sheet.Cell(row, 1).Value = e.Id;
            sheet.Cell(row, 2).Value = e.BadgeNo ?? "";
            sheet.Cell(row, 3).Value = e.Name ?? "";
            sheet.Cell(row, 4).Value = e.CompanyName ?? "";
            sheet.Cell(row, 5).Value = e.ProjectCode ?? "";
            sheet.Cell(row, 6).Value = e.ProjectName ?? "";
            sheet.Cell(row, 7).Value = e.DeptName ?? "";
            sheet.Cell(row, 8).Value = e.Designation ?? "";
            sheet.Cell(row, 9).Value = e.StatusActive == 1 ? "Active" : "Inactive";
            sheet.Cell(row, 10).Value = e.CreatedDate?.ToString("yyyy-MM-dd HH:mm") ?? "";
        }

        sheet.Row(1).Style.Font.Bold = true;
        sheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public static byte[] BuildPdf(List<EmployeeResponse> employees)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(20, Unit.Millimetre);
                page.DefaultTextStyle(x => x.FontSize(9));

                page.Header().Text("Employee Report").FontSize(16).Bold().AlignCenter();

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(0.6f);
                        columns.RelativeColumn(1f);
                        columns.RelativeColumn(1.8f);
                        columns.RelativeColumn(1.8f);
                        columns.RelativeColumn(1.2f);
                        columns.RelativeColumn(1.8f);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(1.5f);
                        columns.RelativeColumn(1f);
                        columns.RelativeColumn(1.4f);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten2).Text("ID").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Badge No").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Name").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Company").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Project Code").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Project Name").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Dept").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Designation").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Status").Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Text("Created Date").Bold();
                    });

                    foreach (var e in employees)
                    {
                        table.Cell().Text(e.Id.ToString());
                        table.Cell().Text(e.BadgeNo ?? "-");
                        table.Cell().Text(e.Name ?? "-");
                        table.Cell().Text(e.CompanyName ?? "-");
                        table.Cell().Text(e.ProjectCode ?? "-");
                        table.Cell().Text(e.ProjectName ?? "-");
                        table.Cell().Text(e.DeptName ?? "-");
                        table.Cell().Text(e.Designation ?? "-");
                        table.Cell().Text(e.StatusActive == 1 ? "Active" : "Inactive");
                        table.Cell().Text(e.CreatedDate?.ToString("yyyy-MM-dd") ?? "-");
                    }
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });
            });
        }).GeneratePdf();
    }
}
