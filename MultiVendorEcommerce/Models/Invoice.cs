using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Invoice : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; }

    public bool? Status { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
