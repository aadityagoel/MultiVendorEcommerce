using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Account : IEntity
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public string? StoreName { get; set; }

    public string? StoreAddress { get; set; }

    public string? StorePhone { get; set; }

    public string? StoreWebsite { get; set; }

    public string? StoreLogo { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role Role { get; set; }
}
