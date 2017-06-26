﻿using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class CustomersController : Controller
   {
      private readonly ApplicationDbContext _context;

      public CustomersController()
      {
         _context = new ApplicationDbContext();
      }

      protected override void Dispose(bool disposing)
      {
         _context.Dispose();
      }

      public ActionResult Index()
      {
         var customers = _context.Customers.Include(c => c.MembershipType).ToList();
         
         return View(customers);
      }

      [Route(@"Customers/Details/{id:regex(\d)}")]
      public ActionResult CustomerDetails(int id)
      {
         var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

         if (customer == null)
         {
            return HttpNotFound();
         }

         return View(customer);
      }

      public ActionResult New()
      {
         var viewmodel = new NewCustomerViewModel {MembershipTypes = _context.MembershipTypes.ToList()};

         return View(viewmodel);
      }
   }
}