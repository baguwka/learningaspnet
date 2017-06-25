using System.Collections.Generic;
using System.Linq;
using Vidly.Models;

namespace Vidly.BusinessLogic
{
   public class CustomersDataBase
   {
      private static CustomersDataBase _instance;
      private readonly List<Customer> _customers;
      public static CustomersDataBase Instance => _instance ?? (_instance = new CustomersDataBase());

      private CustomersDataBase()
      {
         _customers = new List<Customer>
         {
            new Customer{Id = 0, Name = "Valerii Dmitriev"},
            new Customer{Id = 1, Name = "John Smith"},
            new Customer{Id = 2, Name = "Mary Williams"},
         };
      }

      public IEnumerable<Customer> GetActualCustomers()
      {
         return _customers.ToList();
      }
   }
}