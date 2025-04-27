using System;
using System.Collections.Generic;

namespace textile.Models;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string Suppliername { get; set; } = null!;

    public string? Contactinfo { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
