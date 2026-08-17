using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace crud_sharp.App.Services;

// ── Data Model ────────────────────────────────────────────────────────
public class RadiographicReportData
{
    // Header info
    public string Company            { get; set; } = "";
    public string ReportNo           { get; set; } = "";
    public string ProjectName        { get; set; } = "";
    public string RfiNo              { get; set; } = "";
    public string StandardCode       { get; set; } = "";
    public string PageNo             { get; set; } = "";
    public string AcceptanceCriteria { get; set; } = "";
    public string DateOfInspection   { get; set; } = "";
    public string ProcedureNo        { get; set; } = "";
    public string DateOfRfi          { get; set; } = "";
    public string GaDrawingNo        { get; set; } = "";
    public string TestingLocation    { get; set; } = "";
    public string TitleDrawing       { get; set; } = "";
    public string JobNo              { get; set; } = "";
    public string GradeMaterial      { get; set; } = "";
    public string DeliveryCondition  { get; set; } = "";
    public string PwhtStatus         { get; set; } = "";
    public string BlockName          { get; set; } = "";
    public string NdtContractor      { get; set; } = "";
    public string BlockNo            { get; set; } = "";
    public string TechnicianName     { get; set; } = "";

    // Surface Condition
    public string SurfaceAsWelded      { get; set; } = "";
    public string SurfaceBrushCleaned  { get; set; } = "";
    public string SurfaceGroundFlush   { get; set; } = "";
    public string SurfaceOthers        { get; set; } = "";

    // Examination Stage
    public string ExamAfterWeldCooled  { get; set; } = "";
    public string ExamAfterPwht        { get; set; } = "";
    public string ExamAfterRepair      { get; set; } = "";

    // Part
    public string PartName             { get; set; } = "";
    public string PartSizeIdOd         { get; set; } = "";
    public string PartSch              { get; set; } = "";
    public string PartMatType          { get; set; } = "";
    public string PartMatThk           { get; set; } = "";
    public bool   PartMatThkIn         { get; set; } = false;
    public bool   PartMatThkMm         { get; set; } = true;
    public string PartWeldThk          { get; set; } = "";
    public bool   PartWeldThkIn        { get; set; } = false;
    public bool   PartWeldThkMm        { get; set; } = true;
    public string PartReinforcThk      { get; set; } = "";
    public bool   PartReinforcThkIn    { get; set; } = false;
    public bool   PartReinforcThkMm    { get; set; } = true;
    public bool   PartBackingRingYes   { get; set; } = false;
    public bool   PartBackingRingNo    { get; set; } = true;

    // Film
    public string FilmManufacture      { get; set; } = "";
    public string FilmType             { get; set; } = "";
    public string FilmDimension        { get; set; } = "";
    public string FilmTotal            { get; set; } = "";

    // Screen
    public string ScreenLead           { get; set; } = "";
    public string ScreenThickness      { get; set; } = "";
    public bool   ScreenThkIn         { get; set; } = false;
    public bool   ScreenThkMm         { get; set; } = true;

    // Radiation Source
    public bool   RadIsotopeIr192      { get; set; } = false;
    public bool   RadIsotopeCo60       { get; set; } = false;
    public bool   RadIsotopeOther      { get; set; } = true;
    public string RadIsotopeOtherText  { get; set; } = "SE75";
    public string RadActivity          { get; set; } = "";
    public string RadActivityKv        { get; set; } = "13";
    public string RadCurrentA          { get; set; } = "";
    public string RadSizeFocalSpot     { get; set; } = "3.2";

    // Technique
    public bool   TechRtClassA         { get; set; } = false;
    public bool   TechRtClassB         { get; set; } = true;
    public string TechGeomUnsharpness  { get; set; } = "0.05";
    public string TechSfd              { get; set; } = "457.2";
    public bool   TechExposureSingle   { get; set; } = true;
    public bool   TechExposureDouble   { get; set; } = false;
    public bool   TechViewingSingle    { get; set; } = true;
    public bool   TechViewingDouble    { get; set; } = false;
    public string TechExposureTime     { get; set; } = "35 Mnt 31 Sec Mnt";
    public string TechSod              { get; set; } = "449.2";
    public string TechDssof            { get; set; } = "8";
    public bool   TechFilmSingle       { get; set; } = true;
    public bool   TechFilmMultiple     { get; set; } = false;

    // IQI
    public bool   IqiAstm              { get; set; } = false;
    public bool   IqiEnDin             { get; set; } = true;
    public bool[] IqiWires             { get; set; } = new bool[20]; // index 0=wire1..19=wire20
    public bool   IqiPlacementSource   { get; set; } = true;
    public bool   IqiPlacementFilm     { get; set; } = false;
    public string IqiBlockThickness    { get; set; } = "";

    // Marker Placement
    public bool   MarkerSourceSide     { get; set; } = true;
    public bool   MarkerFilmSide       { get; set; } = false;
    public bool   MarkerBackscatterYes { get; set; } = true;
    public bool   MarkerBackscatterNo  { get; set; } = false;

    // Sketch selection
    public bool   SketchPanoramicSwsv  { get; set; } = false;
    public bool   SketchSwsv           { get; set; } = false;
    public bool   SketchSwsvB          { get; set; } = true;
    public bool   SketchDwsv           { get; set; } = false;
    public bool   SketchDwsvB          { get; set; } = false;
    public bool   SketchDwvd           { get; set; } = false;
    public bool   SketchDwvdB          { get; set; } = false;
    public bool   SketchOther          { get; set; } = false;

    // Joint List
    public List<JointItem> Joints      { get; set; } = new();
}

// ── Joint Item ────────────────────────────────────────────────────────
public class JointItem
{
    public int    Sn                  { get; set; }
    public string WeldMapDwg          { get; set; } = "";
    public string JointNo             { get; set; } = "";
    public string Location            { get; set; } = "";
    public string InspectionCategory  { get; set; } = "";
    public string TotalLength         { get; set; } = "";
    public string TestedLength        { get; set; } = "";
    public string WeldingProcess      { get; set; } = "";
    public string Wps                 { get; set; } = "";
    public string WelderId            { get; set; } = "";
    public string ResultAcc           { get; set; } = "";
    public string ResultRej           { get; set; } = "";
    public string DensityMax          { get; set; } = "";
    public string DensityMin          { get; set; } = "";
    public string SensitivityIqi      { get; set; } = "";
    public string SensitivityWireNo   { get; set; } = "";
    public string DiscontinuitiesType { get; set; } = "";
    public string Remark              { get; set; } = "";
}

// ── Service ───────────────────────────────────────────────────────────
public static class SampleReportService
{
    private static RadiographicReportData DefaultData()
    {
        var d = new RadiographicReportData
        {
            Company            = "Tennet",
            ReportNo           = "WT-265",
            ProjectName        = "Tennet 2GW - Gamma",
            RfiNo              = "TBY-2GWG-TS-S-RFI-NDT-RT-000726",
            StandardCode       = "<p>DNV-CG-0051</p>",
            PageNo             = "",
            AcceptanceCriteria = "<ul><li>ISO 10675-1 ACCEPTANCE LEVEL 1</li></ul>",
            DateOfInspection   = "2026-03-15",
            ProcedureNo        = "<ul><li>IV3-GSC-0000352-MA-EN; Radiography Testing Procedure Rev. 00</li></ul>",
            DateOfRfi          = "2026-03-15",
            GaDrawingNo        = "AS-1051-02 Rev.",
            TestingLocation    = "TBY - YST-19",
            TitleDrawing       = "BLOCK ASSEMBLY DRAWING - 1051 Page 02 of 25",
            JobNo              = "2013J310015",
            GradeMaterial      = "Carbon Steel",
            DeliveryCondition  = "-",
            PwhtStatus         = "N/A",
            BlockName          = "1051",
            NdtContractor      = "WELDTECH",
            BlockNo            = "IDC-IDA",
            TechnicianName     = "KARUPPASAMY PETHANAN",

            SurfaceAsWelded     = "YES",
            SurfaceBrushCleaned = "N/A",
            SurfaceGroundFlush  = "N/A",
            SurfaceOthers       = "N/A",

            ExamAfterWeldCooled = "48 Hours",
            ExamAfterPwht       = "N/A",
            ExamAfterRepair     = "N/A",

            PartName            = "N/A",
            PartSizeIdOd        = "N/A",
            PartSch             = "N/A",
            PartMatType         = "S355J2, S255K2",
            PartMatThk          = "N/A",
            PartWeldThk         = "N/A",
            PartReinforcThk     = "N/A",
            PartBackingRingNo   = true,

            FilmManufacture     = "Agfa",
            FilmType            = "Type-I D4",
            FilmDimension       = "4 X 15",
            FilmTotal           = "4",

            ScreenLead          = "Front Back",
            ScreenThickness     = "0.125",
            ScreenThkMm         = true,

            RadIsotopeOther     = true,
            RadIsotopeOtherText = "SE75",
            RadActivityKv       = "13",
            RadSizeFocalSpot    = "3.2",

            TechRtClassB        = true,
            TechGeomUnsharpness = "0.05",
            TechSfd             = "457.2",
            TechExposureSingle  = true,
            TechViewingSingle   = true,
            TechExposureTime    = "35 Mnt 31 Sec Mnt",
            TechSod             = "449.2",
            TechDssof           = "8",
            TechFilmSingle      = true,

            IqiEnDin            = true,
            IqiPlacementSource  = true,

            MarkerSourceSide    = true,
            MarkerBackscatterYes = true,

            SketchSwsvB         = true,
        };
        // Wire checked: index 15 (wire 16)
        d.IqiWires[15] = true;

        // Sample joints (25 dummy joints)
        d.Joints = new List<JointItem>();
        for (int i = 1; i <= 25; i++)
        {
            d.Joints.Add(new JointItem
            {
                Sn = i,
                WeldMapDwg = "WM-1051-03 Rev. 01",
                JointNo = $"10-B/{i:D2}",
                Location = $"X{i}",
                InspectionCategory = "Special",
                TotalLength = "2900",
                TestedLength = "350",
                WeldingProcess = "FCAW",
                Wps = "FCAW-1G2G3G4G-92",
                WelderId = "30332",
                ResultAcc = i % 2 == 0 ? "ACC" : "-",
                ResultRej = "-",
                DensityMax = (3.0 + (i * 0.05) % 0.8).ToString("F1", System.Globalization.CultureInfo.InvariantCulture),
                DensityMin = "2.8",
                SensitivityIqi = "10",
                SensitivityWireNo = "WV-15",
                DiscontinuitiesType = i % 2 == 0 ? "NAD" : "SL,POR",
                Remark = ""
            });
        }

        return d;
    }

    public static byte[] BuildPdf() => BuildPdf(DefaultData());

    public static byte[] BuildPdf(RadiographicReportData data)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        QuestPDF.Settings.EnableDebugging = true;

        byte[] seatriumLogo = File.ReadAllBytes("Assets/Image/Wikipedia-logo.png");
        byte[] tennetLogo   = File.ReadAllBytes("Assets/Image/Wikipedia-logo.png");
        byte[] checkedImg   = File.ReadAllBytes("Assets/Image/checked.png");
        byte[] uncheckedImg = File.ReadAllBytes("Assets/Image/uncheck.png");
        byte[] sketchImg    = File.ReadAllBytes("Assets/Image/Wikipedia-logo.png");

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Portrait());
                page.Margin(8);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(6.5f).FontFamily("Arial"));

                // ══════════════════════════════════════════════════════
                // HEADER — tampil di setiap halaman
                // ══════════════════════════════════════════════════════
                page.Header().Border(1).BorderColor(Colors.Black).Column(outer =>
                {
                    // Logo + judul
                    outer.Item().BorderBottom(1).BorderColor(Colors.Black).Table(table =>
                    {
                        table.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn(2);
                            c.RelativeColumn(6);
                            c.RelativeColumn(2);
                        });

                        table.Cell().Row(1).Column(1)
                            .Padding(3).AlignLeft().AlignMiddle()
                            .Height(24).Image(seatriumLogo).FitArea();

                        table.Cell().Row(1).Column(2)
                            .Padding(3).AlignCenter().AlignMiddle()
                            .Text("Tennet 2GW - Ijmuiden Ver Gamma")
                            .FontSize(9).Bold();

                        table.Cell().Row(1).Column(3)
                            .Padding(3).AlignRight().AlignMiddle()
                            .Height(24).Image(tennetLogo).FitArea();
                    });

                    // Banner
                    outer.Item().BorderBottom(1).BorderColor(Colors.Black)
                        .Padding(2).AlignCenter()
                        .Text("RADIOGRAPHIC TEST REPORT")
                        .Bold().FontSize(7.5f);

                    // Info Grid
                    outer.Item().Table(table =>
                    {
                        table.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn(3.5f);
                            c.ConstantColumn(7);
                            c.RelativeColumn(5.5f);
                            c.RelativeColumn(3);
                            c.ConstantColumn(7);
                            c.RelativeColumn(4);
                        });

                        uint row = 1;

                        InfoRow(table, ref row, "COMPANY", data.Company, false, "REPORT NO.", data.ReportNo, false);
                        InfoRow(table, ref row, "Project Name", data.ProjectName, false, "RFI NO.", data.RfiNo, false);
                        InfoRow(table, ref row, "Standard / Code", data.StandardCode, true, "Page No", data.PageNo, false);
                        InfoRow(table, ref row, "Acceptance Criteria", data.AcceptanceCriteria, true, "Date Of Inspection", data.DateOfInspection, false);
                        InfoRow(table, ref row, "Procedure No.", data.ProcedureNo, true, "Date Of RFI", data.DateOfRfi, false);
                        InfoRow(table, ref row, "GA/ASSY/ISOMETRIC Drawing No.", data.GaDrawingNo, false, "Testing Location", data.TestingLocation, false);

                        uint titleRow = row;
                        table.Cell().Row(titleRow).RowSpan(4).Column(1)
                            .BorderBottom(1).BorderColor(Colors.Black)
                            .PaddingHorizontal(3).PaddingVertical(1).AlignTop()
                            .Text("Title Drawing").Bold();
                        table.Cell().Row(titleRow).RowSpan(4).Column(2)
                            .BorderBottom(1).BorderColor(Colors.Black)
                            .AlignTop().AlignCenter().PaddingVertical(1).Text(":");
                        table.Cell().Row(titleRow).RowSpan(4).Column(3)
                            .BorderBottom(1).BorderColor(Colors.Black)
                            .BorderRight(1).BorderColor(Colors.Black)
                            .PaddingHorizontal(3).PaddingVertical(1).AlignTop()
                            .Text(data.TitleDrawing);

                        RightOnlyRow(table, titleRow + 0, "Job No.",            data.JobNo);
                        RightOnlyRow(table, titleRow + 1, "Grade Material",     data.GradeMaterial);
                        RightOnlyRow(table, titleRow + 2, "Delivery Condition", data.DeliveryCondition);
                        RightOnlyRow(table, titleRow + 3, "PWHT Status",        data.PwhtStatus);
                        row += 4;

                        InfoRow(table, ref row, "Block Name", data.BlockName, false, "NDT Contractor", data.NdtContractor, false);
                        InfoRow(table, ref row, "Block No",   data.BlockNo,   false, "Technician Name", data.TechnicianName, false);
                    });
                });

                // ══════════════════════════════════════════════════════
                // CONTENT — detail tabel (3 kolom besar) + joint list
                // ══════════════════════════════════════════════════════
                page.Content().PaddingTop(4).Column(pageCol =>
                {
                    // ── 3-column detail table ───────────────────────
                    pageCol.Item().Border(1).BorderColor(Colors.Black).Table(main =>
                    {
                    main.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(3); // Kiri
                        c.RelativeColumn(4); // Tengah
                        c.RelativeColumn(3); // Kanan
                    });

                    // ── KOLOM KIRI ─────────────────────────────────────
                    main.Cell().Row(1).Column(1)
                        .BorderRight(1).BorderColor(Colors.Black)
                        .Column(left => // checkedImg, uncheckedImg passed via closure
                    {
                        // Surface Condition
                        SectionHeader(left, "Surface Condition");
                        left.Item().Table(t =>
                        {
                            TwoCol(t);
                            uint r = 1;
                            LabelValue(t, ref r, "As Welded",     data.SurfaceAsWelded);
                            LabelValue(t, ref r, "Brush Cleaned", data.SurfaceBrushCleaned);
                            LabelValue(t, ref r, "Ground Flush",  data.SurfaceGroundFlush);
                            LabelValue(t, ref r, "Others",        data.SurfaceOthers);
                        });

                        // Examination Stage
                        SectionHeader(left, "Examination Stage");
                        left.Item().Table(t =>
                        {
                            TwoCol(t);
                            uint r = 1;
                            LabelValue(t, ref r, "After Weld Completely Cooled", data.ExamAfterWeldCooled);
                            LabelValue(t, ref r, "After PWHT",                   data.ExamAfterPwht);
                            LabelValue(t, ref r, "After Repair (Grinding)",      data.ExamAfterRepair);
                        });

                        // Part
                        SectionHeader(left, "PART");
                        left.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(3);
                                c.ConstantColumn(10);
                                c.RelativeColumn(3);
                                c.RelativeColumn(2);
                            });
                            uint r = 1;

                            // Name
                            t.Cell().Row(r).Column(1).Padding(3).Text("Name").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartName);
                            t.Cell().Row(r).Column(4).Padding(3).Text(""); r++;

                            // Size/ID/OD
                            t.Cell().Row(r).Column(1).Padding(3).Text("Size / ID / OD").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartSizeIdOd);
                            t.Cell().Row(r).Column(4).Padding(3).Text("mm/inch"); r++;

                            // Sch
                            t.Cell().Row(r).Column(1).Padding(3).Text("Sch").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartSch);
                            t.Cell().Row(r).Column(4).Padding(3).Text(""); r++;

                            // Mat'l Type
                            t.Cell().Row(r).Column(1).Padding(3).Text("Mat'l Type").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).ColumnSpan(2).Padding(3).Text(data.PartMatType); r++;

                            // Mat'l Thk
                            t.Cell().Row(r).Column(1).Padding(3).Text("Mat'l Thk.").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartMatThk);
                            t.Cell().Row(r).Column(4).Padding(3).Row(rr => { CheckImg(rr, data.PartMatThkIn, "In", checkedImg, uncheckedImg); CheckImg(rr, data.PartMatThkMm, "mm", checkedImg, uncheckedImg); }); r++;

                            // Weld Thk
                            t.Cell().Row(r).Column(1).Padding(3).Text("Weld Thk.").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartWeldThk);
                            t.Cell().Row(r).Column(4).Padding(3).Row(rr => { CheckImg(rr, data.PartWeldThkIn, "In", checkedImg, uncheckedImg); CheckImg(rr, data.PartWeldThkMm, "mm", checkedImg, uncheckedImg); }); r++;

                            // Reinforc Thk
                            t.Cell().Row(r).Column(1).Padding(3).Text("Reinforc. Thk.").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.PartReinforcThk);
                            t.Cell().Row(r).Column(4).Padding(3).Row(rr => { CheckImg(rr, data.PartReinforcThkIn, "In", checkedImg, uncheckedImg); CheckImg(rr, data.PartReinforcThkMm, "mm", checkedImg, uncheckedImg); }); r++;

                            // Backing Ring
                            t.Cell().Row(r).Column(1).Padding(3).Text("Backing Ring").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).ColumnSpan(2).Padding(3).Row(rr => { CheckImg(rr, data.PartBackingRingYes, "Yes", checkedImg, uncheckedImg); CheckImg(rr, data.PartBackingRingNo, "No", checkedImg, uncheckedImg); }); r++;
                        });

                        // Film
                        SectionHeader(left, "FILM");
                        left.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(3);
                                c.ConstantColumn(10);
                                c.RelativeColumn(3);
                                c.RelativeColumn(2);
                            });
                            uint r = 1;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Manufacture's").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).ColumnSpan(2).Padding(3).Text(data.FilmManufacture); r++;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Type of Film").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).ColumnSpan(2).Padding(3).Text(data.FilmType); r++;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Dimension").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.FilmDimension);
                            t.Cell().Row(r).Column(4).Padding(3).Text("In"); r++;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Total of Film").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.FilmTotal);
                            t.Cell().Row(r).Column(4).Padding(3).Text("Sheet(s)"); r++;
                        });

                        // Screen
                        SectionHeader(left, "SCREEN");
                        left.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(3);
                                c.ConstantColumn(10);
                                c.RelativeColumn(3);
                                c.RelativeColumn(2);
                            });
                            uint r = 1;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Lead").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).ColumnSpan(2).Padding(3).Text(data.ScreenLead); r++;

                            t.Cell().Row(r).Column(1).Padding(3).Text("Thickness").Bold();
                            t.Cell().Row(r).Column(2).AlignCenter().Padding(3).Text(":");
                            t.Cell().Row(r).Column(3).Padding(3).Text(data.ScreenThickness);
                            t.Cell().Row(r).Column(4).Padding(3).Row(rr => { CheckImg(rr, data.ScreenThkIn, "In", checkedImg, uncheckedImg); CheckImg(rr, data.ScreenThkMm, "mm", checkedImg, uncheckedImg); }); r++;
                        });
                    });

                    // ── KOLOM TENGAH ───────────────────────────────────
                    main.Cell().Row(1).Column(2)
                        .BorderRight(1).BorderColor(Colors.Black)
                        .Column(mid =>
                    {
                        // Radiation Source
                        SectionHeader(mid, "RADIATION SOURCE");
                        mid.Item().Padding(4).Column(rs =>
                        {
                            // Isotope
                            rs.Item().Row(rr =>
                            {
                                rr.AutoItem().Text("Isotope").Bold();
                                rr.ConstantItem(10).AlignCenter().Text(":");
                                rr.RelativeItem().Row(ir =>
                                {
                                    CheckImg(ir, data.RadIsotopeIr192, "Ir-192", checkedImg, uncheckedImg);
                                    CheckImg(ir, data.RadIsotopeCo60,  "Co-60",  checkedImg, uncheckedImg);
                                    CheckImg(ir, data.RadIsotopeOther, $"Other {data.RadIsotopeOtherText}", checkedImg, uncheckedImg);
                                });
                            });

                            // Activity
                            rs.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Activity").Bold();
                                rr.ConstantItem(10).AlignCenter().Text(":");
                                rr.RelativeItem().Row(ir =>
                                {
                                    CheckImg(ir, true, "Ci", checkedImg, uncheckedImg);
                                    ir.AutoItem().Text($"  Kv :  {data.RadActivityKv}");
                                });
                            });

                            // Current A
                            rs.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Current A").Bold();
                                rr.ConstantItem(10).AlignCenter().Text(":");
                                rr.RelativeItem().Text(data.RadCurrentA);
                            });

                            // Size / Focal Spot
                            rs.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Size / Focal Spot").Bold();
                                rr.ConstantItem(10).AlignCenter().Text(":");
                                rr.RelativeItem().Text(data.RadSizeFocalSpot);
                                rr.AutoItem().Text("mm");
                            });
                        });

                        // Technique
                        SectionHeader(mid, "TECHNIQUE");
                        mid.Item().Padding(4).Column(tc =>
                        {
                            // RT Class
                            tc.Item().Row(rr => { CheckImg(rr, data.TechRtClassA, "RT CLASS A", checkedImg, uncheckedImg); CheckImg(rr, data.TechRtClassB, "RT CLASS B", checkedImg, uncheckedImg); });

                            tc.Item().PaddingTop(3).Row(rr => { rr.AutoItem().Text("Geometric Unsharpness").Bold(); rr.AutoItem().Text($" : {data.TechGeomUnsharpness}"); });
                            tc.Item().PaddingTop(3).Text($"SFD : {data.TechSfd}");

                            tc.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Exposure").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.TechExposureSingle, "Single Wall", checkedImg, uncheckedImg);
                                CheckImg(rr, data.TechExposureDouble, "Double Wall", checkedImg, uncheckedImg);
                            });

                            tc.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Viewing").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.TechViewingSingle, "Single Wall", checkedImg, uncheckedImg);
                                CheckImg(rr, data.TechViewingDouble, "Double Wall", checkedImg, uncheckedImg);
                            });

                            tc.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Exposure Time").Bold();
                                rr.AutoItem().Text($" : {data.TechExposureTime} ");
                                CheckImg(rr, true, "", checkedImg, uncheckedImg);
                            });

                            tc.Item().PaddingTop(3).Text(t =>
                            {
                                t.Span("SOD*").Bold();
                                t.Span($" : {data.TechSod} mm  ");
                                t.Span("DSSOF**").Bold();
                                t.Span($" : {data.TechDssof} mm");
                            });

                            tc.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("No of Film in Holder").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.TechFilmSingle,   "Single",   checkedImg, uncheckedImg);
                                CheckImg(rr, data.TechFilmMultiple, "Multiple", checkedImg, uncheckedImg);
                            });
                        });

                        // IQI
                        SectionHeader(mid, "IMAGE QUALITY INDICATOR ( IQI )");
                        mid.Item().Padding(4).Column(iqi =>
                        {
                            // Penetrameter type
                            iqi.Item().Row(rr =>
                            {
                                rr.AutoItem().Text("Type of Penetrameter").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.IqiAstm,  "ASTM",   checkedImg, uncheckedImg);
                                CheckImg(rr, data.IqiEnDin, "EN/DIN", checkedImg, uncheckedImg);
                            });

                            // Wire checkboxes 1-20
                            iqi.Item().PaddingTop(3).Row(rr => { rr.AutoItem().Text("Wire").Bold(); rr.AutoItem().Text(" : "); });

                            // Row 1: wire 1-10
                            iqi.Item().Row(rr =>
                            {
                                for (int i = 0; i < 10; i++)
                                    CheckImg(rr, data.IqiWires[i], $"{i + 1}", checkedImg, uncheckedImg);
                            });
                            // Row 2: wire 11-20
                            iqi.Item().Row(rr =>
                            {
                                for (int i = 10; i < 20; i++)
                                    CheckImg(rr, data.IqiWires[i], $"{i + 1}", checkedImg, uncheckedImg);
                            });

                            // Placement
                            iqi.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Placement").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.IqiPlacementSource, "Source Side", checkedImg, uncheckedImg);
                                CheckImg(rr, data.IqiPlacementFilm,   "Film Side",   checkedImg, uncheckedImg);
                            });

                            // Block Thickness
                            iqi.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Block Thickness").Bold();
                                rr.AutoItem().Text($" : {data.IqiBlockThickness}  mm");
                            });
                        });

                        // Marker Placement
                        SectionHeader(mid, "MARKER PLACEMENT");
                        mid.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Column(mp =>
                        {
                            mp.Item().Row(rr =>
                            {
                                CheckImg(rr, data.MarkerSourceSide, "Source Side", checkedImg, uncheckedImg);
                                CheckImg(rr, data.MarkerFilmSide,   "Film Side",   checkedImg, uncheckedImg);
                            });

                            mp.Item().PaddingTop(3).Row(rr =>
                            {
                                rr.AutoItem().Text("Use back scatter").Bold();
                                rr.AutoItem().Text(" : ");
                                CheckImg(rr, data.MarkerBackscatterYes, "Yes", checkedImg, uncheckedImg);
                                CheckImg(rr, data.MarkerBackscatterNo,  "No",  checkedImg, uncheckedImg);
                            });
                        });
                    });

                    // ── KOLOM KANAN ────────────────────────────────────
                    main.Cell().Row(1).Column(3).Column(right =>
                    {
                        // Sketch header
                        SectionHeader(right, "EXPOSURE TECHNIQUE SKETCH");

                        // Sketch grid 2x4
                        right.Item().Padding(4).Table(sk =>
                        {
                            sk.ColumnsDefinition(c => { c.RelativeColumn(); c.RelativeColumn(); });

                            uint sr = 1;
                            SketchCell(sk, sr, 1, data.SketchPanoramicSwsv, "Panoramic / SWSV", checkedImg, uncheckedImg);
                            SketchCell(sk, sr, 2, data.SketchSwsv,          "SWSV",             checkedImg, uncheckedImg); sr++;
                            SketchCell(sk, sr, 1, data.SketchSwsvB,         "SWSV",             checkedImg, uncheckedImg);
                            SketchCell(sk, sr, 2, data.SketchDwsv,          "DWSV",             checkedImg, uncheckedImg); sr++;
                            SketchCell(sk, sr, 1, data.SketchDwvd,          "DWSV",             checkedImg, uncheckedImg);
                            SketchCell(sk, sr, 2, data.SketchDwvdB,         "DWVD",             checkedImg, uncheckedImg); sr++;
                            SketchCell(sk, sr, 1, data.SketchDwvd,          "DWDV",             checkedImg, uncheckedImg);
                            SketchCell(sk, sr, 2, data.SketchOther,         "Other",            checkedImg, uncheckedImg); sr++;
                        });

                        // Notes
                        right.Item().BorderTop(1).BorderBottom(1).BorderColor(Colors.Black).Padding(4).Column(n =>
                        {
                            n.Item().Text("Notes for Sketch").Bold();
                            n.Item().PaddingTop(2).Text("1.  SWSV = Single Wall Single Viewing");
                            n.Item().Text("2.  DWSV = Double Wall Single Viewing");
                            n.Item().Text("3.  DWDV = Double Wall Double Viewing");
                            n.Item().Text("4.  Other = Other than listed ( Please Sketch )");
                        });
                    });
                });

                    // ── Joint List table ─────────────────────────────────────────
                    pageCol.Item().PaddingTop(4).Border(1).BorderColor(Colors.Black).Table(jt =>
                    {
                        jt.ColumnsDefinition(c =>
                        {
                            c.ConstantColumn(16);  // S/N
                            c.RelativeColumn(3);   // Weld Map Dwg
                            c.RelativeColumn(2);   // Joint No
                            c.RelativeColumn(1.5f);// Location
                            c.RelativeColumn(2);   // Inspection Category
                            c.RelativeColumn(1.5f);// Total Length
                            c.RelativeColumn(1.5f);// Tested Length
                            c.RelativeColumn(1.5f);// Welding Process
                            c.RelativeColumn(2.5f);// WPS
                            c.RelativeColumn(1.5f);// Welder ID
                            c.RelativeColumn(1);   // ACC
                            c.RelativeColumn(1);   // REJ
                            c.RelativeColumn(1);   // Density Max
                            c.RelativeColumn(1);   // Density Min
                            c.RelativeColumn(1);   // IQI
                            c.RelativeColumn(1.5f);// Wire No
                            c.RelativeColumn(2);   // Discontinuities
                            c.RelativeColumn(1.5f);// Remark
                        });

                        jt.Header(header =>
                        {
                            JointHeader(header, 1,  1, 2, 1, "S/N");
                            JointHeader(header, 1,  2, 2, 1, "Weld Map Dwg /\nLine & Spool No.");
                            JointHeader(header, 1,  3, 2, 1, "Joint\nNo.");
                            JointHeader(header, 1,  4, 2, 1, "Location");
                            JointHeader(header, 1,  5, 2, 1, "Inspection\nCategory");
                            JointHeader(header, 1,  6, 2, 1, "Total\nLength\n(mm)");
                            JointHeader(header, 1,  7, 2, 1, "Tested\nLength\n(mm)");
                            JointHeader(header, 1,  8, 2, 1, "Welding\nProcess");
                            JointHeader(header, 1,  9, 2, 1, "WPS");
                            JointHeader(header, 1, 10, 2, 1, "Welder ID");
                            JointHeader(header, 1, 11, 1, 2, "Result");
                            JointHeader(header, 1, 13, 1, 2, "Density");
                            JointHeader(header, 1, 15, 1, 2, "Sensitivity");
                            JointHeader(header, 1, 17, 2, 1, "Discontinuities\nType");
                            JointHeader(header, 1, 18, 2, 1, "Remark");
                            JointHeader(header, 2, 11, 1, 1, "ACC");
                            JointHeader(header, 2, 12, 1, 1, "REJ");
                            JointHeader(header, 2, 13, 1, 1, "Max");
                            JointHeader(header, 2, 14, 1, 1, "Min");
                            JointHeader(header, 2, 15, 1, 1, "IQI");
                            JointHeader(header, 2, 16, 1, 1, "Wire\nNo");
                        });

                        uint dr = 3;
                        foreach (var j in data.Joints)
                        {
                            JointData(jt, dr,  1, j.Sn.ToString());
                            JointData(jt, dr,  2, j.WeldMapDwg, false);
                            JointData(jt, dr,  3, j.JointNo);
                            JointData(jt, dr,  4, j.Location);
                            JointData(jt, dr,  5, j.InspectionCategory);
                            JointData(jt, dr,  6, j.TotalLength);
                            JointData(jt, dr,  7, j.TestedLength);
                            JointData(jt, dr,  8, j.WeldingProcess);
                            JointData(jt, dr,  9, j.Wps);
                            JointData(jt, dr, 10, j.WelderId);
                            JointData(jt, dr, 11, j.ResultAcc);
                            JointData(jt, dr, 12, j.ResultRej);
                            JointData(jt, dr, 13, j.DensityMax);
                            JointData(jt, dr, 14, j.DensityMin);
                            JointData(jt, dr, 15, j.SensitivityIqi);
                            JointData(jt, dr, 16, j.SensitivityWireNo);
                            JointData(jt, dr, 17, j.DiscontinuitiesType);
                            JointData(jt, dr, 18, j.Remark);
                            dr++;
                        }
                    });
                });


                // ── Footer ───────────────────────────────────────────
                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });
            });
        }).GeneratePdf();
    }

    // ── Header Info: InfoRow ──────────────────────────────────────────
    private static void InfoRow(
        TableDescriptor table, ref uint row,
        string leftLabel, string leftValue, bool leftIsHtml,
        string rightLabel, string rightValue, bool rightIsHtml)
    {
        const float bt = 1f;
        var bc = Colors.Black;

        table.Cell().Row(row).Column(1).BorderBottom(bt).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1).Text(leftLabel).Bold();
        table.Cell().Row(row).Column(2).BorderBottom(bt).BorderColor(bc).AlignCenter().PaddingVertical(1).Text(string.IsNullOrEmpty(leftLabel) ? "" : ":");

        var lc = table.Cell().Row(row).Column(3).BorderBottom(bt).BorderColor(bc).BorderRight(1).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1);
        if (leftIsHtml) lc.Column(c => c.Item().Text(StripHtml(leftValue))); else lc.Text(leftValue);

        table.Cell().Row(row).Column(4).BorderBottom(bt).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1).Text(rightLabel).Bold();
        table.Cell().Row(row).Column(5).BorderBottom(bt).BorderColor(bc).AlignCenter().PaddingVertical(1).Text(string.IsNullOrEmpty(rightLabel) ? "" : ":");

        var rc = table.Cell().Row(row).Column(6).BorderBottom(bt).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1);
        if (rightLabel.Equals("Page No", StringComparison.OrdinalIgnoreCase))
        {
            rc.Text(text =>
            {
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        }
        else
        {
            if (rightIsHtml) rc.Column(c => c.Item().Text(StripHtml(rightValue))); else rc.Text(rightValue);
        }

        row++;
    }

    private static void RightOnlyRow(TableDescriptor table, uint row, string label, string value)
    {
        const float bt = 1f; var bc = Colors.Black;
        table.Cell().Row(row).Column(4).BorderBottom(bt).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1).Text(label).Bold();
        table.Cell().Row(row).Column(5).BorderBottom(bt).BorderColor(bc).AlignCenter().PaddingVertical(1).Text(":");
        table.Cell().Row(row).Column(6).BorderBottom(bt).BorderColor(bc).PaddingHorizontal(3).PaddingVertical(1).Text(value);
    }

    // ── Section header (bold center, border atas bawah) ───────────────
    private static void SectionHeader(ColumnDescriptor col, string title)
    {
        col.Item()
            .BorderTop(1).BorderBottom(1).BorderColor(Colors.Black)
            .Padding(3).AlignCenter()
            .Text(title).Bold();
    }

    // ── 2-kolom definition untuk LabelValue ───────────────────────────
    private static void TwoCol(TableDescriptor t)
    {
        t.ColumnsDefinition(c =>
        {
            c.RelativeColumn(3);
            c.ConstantColumn(10);
            c.RelativeColumn(4);
        });
    }

    // ── Label : Value baris ───────────────────────────────────────────
    private static void LabelValue(TableDescriptor t, ref uint row, string label, string value)
    {
        t.Cell().Row(row).Column(1).Padding(3).Text(label).Bold();
        t.Cell().Row(row).Column(2).AlignCenter().Padding(3).Text(":");
        t.Cell().Row(row).Column(3).Padding(3).Text(value);
        row++;
    }

    // ── Checkbox menggunakan gambar PNG ───────────────────────────────
    private static void CheckImg(RowDescriptor row, bool checked_, string label,
        byte[] checkedImg, byte[] uncheckedImg)
    {
        row.AutoItem().Width(6).Height(6).AlignMiddle()
            .Image(checked_ ? checkedImg : uncheckedImg).FitArea();
        if (!string.IsNullOrEmpty(label))
            row.AutoItem().PaddingLeft(1).PaddingRight(1).AlignMiddle().Text(label);
    }

    // ── Sketch cell ───────────────────────────────────────────────────
    private static void SketchCell(TableDescriptor t, uint row, uint col, bool selected, string label,
        byte[] checkedImg, byte[] uncheckedImg)
    {
        t.Cell().Row(row).Column(col).Padding(4).Column(c =>
        {
            c.Item().Row(r =>
            {
                r.AutoItem().Width(10).Height(10).AlignMiddle()
                    .Image(selected ? checkedImg : uncheckedImg).FitArea();
                r.AutoItem().PaddingLeft(3).AlignMiddle().Text(label);
            });
            // Placeholder untuk gambar sketch
            c.Item().Height(40).Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                .AlignCenter().AlignMiddle()
                .Text("[sketch]").FontColor(Colors.Grey.Medium).FontSize(7);
        });
    }

    // ── Strip HTML ────────────────────────────────────────────────────
    private static string StripHtml(string html)
    {
        if (string.IsNullOrWhiteSpace(html)) return "";
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<li\s*>",   "• ");
        html = System.Text.RegularExpressions.Regex.Replace(html, @"</li>",     "\n");
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<br\s*/?>", "\n");
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<p\s*>",    "");
        html = System.Text.RegularExpressions.Regex.Replace(html, @"</p>",      "\n");
        html = System.Text.RegularExpressions.Regex.Replace(html, @"<[^>]+>",   "");
        html = System.Net.WebUtility.HtmlDecode(html);
        return html.Trim();
    }

    // ── Joint table helpers ───────────────────────────────────────────
    private static void JointHeader(TableCellDescriptor t, uint row, uint col,
        uint rowSpan, uint colSpan, string text)
    {
        t.Cell().Row(row).Column(col).RowSpan(rowSpan).ColumnSpan(colSpan)
         .Border(0.5f).BorderColor(Colors.Black)
         .Background(Colors.Grey.Lighten3)
         .Padding(2).AlignCenter().AlignMiddle()
         .Text(text).Bold().FontSize(6);
    }

    private static void JointData(TableDescriptor t, uint row, uint col,
        string text, bool center = true)
    {
        var cell = t.Cell().Row(row).Column(col)
            .Border(0.5f).BorderColor(Colors.Black).Padding(2);
        if (center) cell.AlignCenter().AlignMiddle().Text(text).FontSize(6);
        else        cell.AlignLeft().AlignMiddle().Text(text).FontSize(6);
    }
}