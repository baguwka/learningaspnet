using System.Linq;
using System.Web.Mvc;
using Vidly.BusinessLogic;

namespace Vidly.Controllers
{
   public class CustomersController : Controller
   {
      public ActionResult Index()
      {
         var customers = CustomersDataBase.Instance.GetActualCustomers();
         return View(customers);
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