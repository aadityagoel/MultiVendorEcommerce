﻿using MultiVendorEcommerce.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiVendorEcommerce.Models;

public partial class Invoice : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Created { get; set; }

    public string Status { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; }
}
