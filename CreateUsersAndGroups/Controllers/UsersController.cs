using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UsersGroupsData;

namespace CreateUsersAndGroups.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class UsersController : Controller
   {
        public UsersController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.Submitted = false;

            if (HttpContext.Request.Method == "POST")
            {
                ViewBag.Submitted = true;
                var firstname = Request.Form["name"];
                var surname = Request.Form["surname"];
                var age = Request.Form["age"];
                var email = Request.Form["email"];


                UsersGroupsData.DBModels.User newUser = new UsersGroupsData.DBModels.User()
                {
                    Age = Convert.ToUInt16(age),
                    Email = email,
                    FirstName = firstname,
                    LastName = surname,
                };

                HomeController._dbContext.Add(newUser);
                if (HomeController._dbContext.SaveChanges() > 0)
                {
                    ViewBag.Message = " The user was created successfully.";
                }
                else
                {
                    ViewBag.Message = "There was an error while creating the user.";
                }
            }

            return View();
        }
   }
}
