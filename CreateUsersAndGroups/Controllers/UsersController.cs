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
            // Load the data for the client
            var users = HomeController._dbContext.Users.Select(x => x).ToList();

            // Return the view.
            return View(users);
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

                int ageInt;

                // Pass on error message as a response
                if (Int32.TryParse(age, out ageInt))
                {
                    ViewBag.Message = "Invalid age.";
                    return View();
                }

                // Throw exception based on check
                if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(email))
                    throw new Exception("Please make sure all the fields are popuated.");
                    

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
