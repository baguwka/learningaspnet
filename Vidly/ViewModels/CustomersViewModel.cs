﻿using System.Collections.Generic;
using JetBrains.Annotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
   public class CustomersViewModel
   {
      [NotNull]
      public List<Customer> Customers { get; set; } = new List<Customer>();
   }
}