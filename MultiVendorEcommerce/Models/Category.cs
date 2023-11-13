using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Category : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public int ParentId { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category Parent { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
