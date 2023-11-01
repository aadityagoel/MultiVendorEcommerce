using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Membership : IEntity
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int PackageId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual Account Account { get; set; }

    public virtual Package Package { get; set; }
}
