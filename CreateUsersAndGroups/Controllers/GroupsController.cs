using Microsoft.AspNetCore.Mvc;

namespace CreateUsersAndGroups.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        public GroupsController()
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
                var groupName = Request.Form["groupName"];

                UsersGroupsData.DBModels.Group newGroup = new UsersGroupsData.DBModels.Group()
                {
                    GroupName = groupName
                };

                if (HomeController._dbContext.SaveChanges() > 0)
                {
                    ViewBag.Message = " The group was created successfully.";
                }
                else
                {
                    ViewBag.Message = "There was an error while creating the group.";
                }
            }

            return View();
        }
    }
}
