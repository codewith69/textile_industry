using System;
using System.Collections.Generic;

namespace textile.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Productid { get; set; }

    public DateOnly Orderdate { get; set; }

    public decimal? Quantitymeters { get; set; }

    public decimal? Totalprice { get; set; }

    public virtual Product? Product { get; set; }
}
