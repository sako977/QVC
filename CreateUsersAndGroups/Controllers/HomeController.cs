using CreateUsersAndGroups.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UsersGroupsData;

namespace CreateUsersAndGroups.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class HomeController : Controller
   {
      public static UsersGroupsData.AppContext _dbContext = new UsersGroupsData.AppContext();

      public HomeController()
      {
      }

      public IActionResult Index()
      {
         return View();
      }

      [Route("Error")]
      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}