using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITAssignment4.DataLayer.Domain;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("categoryid")]
    public int Id { get; set; }

    [Column("customername")]
    [MaxLength(15)]
    public string Name { get; set; }

    [Column("description")]
    [MaxLength(300)]
    public string Description { get; set; }
}