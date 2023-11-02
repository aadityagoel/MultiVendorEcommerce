using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Package : IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public decimal? Price { get; set; }

    public int? Duration { get; set; }

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
