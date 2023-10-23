using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITAssignment4.DataLayer.Domain;

public class OrderDetails
{
    [Column("orderid")]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Column("productid")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Column("unitprice")] public int UnitPrice { get; set; }

    [Column("quantity")] public int Quantity { get; set; }

    [Column("discount")] public int Discount { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}