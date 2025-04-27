using System;
using System.Collections.Generic;

namespace textile.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public string? Materialtype { get; set; }

    public decimal? Pricepermeter { get; set; }

    public int? Supplierid { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Supplier? Supplier { get; set; }
}
