﻿using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Product : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Details { get; set; }

    public bool Status { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public bool Featured { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
