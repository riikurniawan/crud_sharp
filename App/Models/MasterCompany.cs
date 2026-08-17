using System.ComponentModel.DataAnnotations.Schema;

namespace crud_sharp.App.Models;

[Table("master_company")]
public class MasterCompany
{
    [Column("id")]
    public int Id { get; set; }

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("status_active")]
    public int StatusActive { get; set; } = 1;

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }
}
