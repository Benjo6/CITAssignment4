using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITAssignment4.DataLayer.Domain;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Column("productid")]
    public int Id { get; set; }

    [Column("productname")]
    [StringLength(40)]
    public string Name { get; set; }

    [Column("supplierid")]
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }

    [Column("categoryid")]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [Column("quantityperunit")]
    [StringLength(20)]
    public string QuantityPerUnit { get; set; }

    [Column("unitprice")]
    public int UnitPrice { get; set; }

    [Column("unitsinstock")]
    public int UnitsInStock { get; set; }

    public virtual Category Category { get; set; }
    
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }

}