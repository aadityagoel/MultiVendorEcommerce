using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Photo : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Status { get; set; }

    public bool Featured { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; }
}
