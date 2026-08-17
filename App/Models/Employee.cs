using System.ComponentModel.DataAnnotations.Schema;

namespace crud_sharp.App.Models;

[Table("employee")]
public class Employee
{
    [Column("id")]
    public int Id { get; set; }

    [Column("badge_no")]
    public string? BadgeNo { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Column("project_id")]
    public int? ProjectId { get; set; }

    [Column("dept_id")]
    public int? DeptId { get; set; }

    [Column("designation")]
    public string? Designation { get; set; }

    [Column("status_active")]
    public int StatusActive { get; set; } = 1;

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }

    [Column("updated_by")]
    public string? UpdatedBy { get; set; }

    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; }

    [Column("deleted_by")]
    public string? DeletedBy { get; set; }

    [Column("deleted_date")]
    public DateTime? DeletedDate { get; set; }
}
