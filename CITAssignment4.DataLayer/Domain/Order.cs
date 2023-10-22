using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITAssignment4.DataLayer.Domain;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Column("orderid")]
    public int Id { get; set; }

    [Column("customerid")]
    public string CustomerId { get; set; }

    [Column("employeeid")]
    public int? EmployeeId { get; set; }

    [Column("orderdate")]
    public DateTime? OrderDate { get; set; }

    [Column("requiredate")]
    public DateTime? RequireDate { get; set; }

    [Column("shippeddate")]
    public DateTime? ShippingDate { get; set; }

    [Column("freight")]
    public decimal? Freight { get; set; }

    [Column("shipname")]
    [MaxLength(40)]
    public string ShipName { get; set; }

    [Column("shipcity")]
    [MaxLength(15)]
    public string ShipCity { get; set; }

    [Column("shipaddress")]
    [MaxLength(60)]
    public string ShipAddress { get; set; }

    [Column("shippostalcode")]
    [MaxLength(10)]
    public string ShipPostalCode { get; set; }

    [Column("shipcountry")]
    [MaxLength(15)]
    public string ShipCountry { get; set; }
    
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}