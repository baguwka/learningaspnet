using System.Linq;
using System.Web.Mvc;
using Vidly.BusinessLogic;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   public class CustomersController : Controller
   {
      [Route(@"Customers")]
      public ActionResult Customers()
      {
         var vm = new CustomersViewModel {Customers = CustomersDataBase.Instance.GetActualCustomers()};
         return View(vm);
      }

      [Route(@"Customers/Details/{id}")]
      public ActionResult CustomerDetails(int id)
      {
         var customers = CustomersDataBase.Instance.GetActualCustomers();

         var customer = customers.FirstOrDefault(c => c.Id == id);

         if (customer == null)
         {
            return HttpNotFound();
         }

         return View(customer);
      }
   }
}