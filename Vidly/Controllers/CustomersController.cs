using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class CustomersController : Controller
   {
      [Route(@"Customers")]
      public ActionResult Customers()
      {
         var vm = new CustomersViewModel();
         var customers = new List<Customer>
         {
            new Customer{Id = 0, Name = "Valerii Dmitriev"},
            new Customer{Id = 1, Name = "John Smith"},
            new Customer{Id = 2, Name = "Mary Williams"},

         };
         vm.Customers = customers;

         return View(vm);
      }
   }
}