using System.ComponentModel.DataAnnotations.Schema;

namespace crud_sharp.App.Models;

[Table("master_dept")]
public class MasterDept
{
    [Column("id")]
    public int Id { get; set; }

    [Column("dept_name")]
    public string? DeptName { get; set; }

    [Column("status_active")]
    public int StatusActive { get; set; } = 1;

    [Column("created_by")]
    public string? CreatedBy { get; set; }

    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }
}
