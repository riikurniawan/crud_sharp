using System.ComponentModel.DataAnnotations.Schema;

namespace crud_sharp.App.Models;

[Table("master_project")]
public class MasterProject
{
    [Column("id")]
    public int Id { get; set; }

    [Column("project_code")]
    public string? ProjectCode { get; set; }

    [Column("project_name")]
    public string? ProjectName { get; set; }

    [Column("status_active")]
    public int StatusActive { get; set; } = 1;

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }
}
