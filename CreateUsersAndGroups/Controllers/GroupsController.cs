using CreateUsersAndGroups.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UsersGroupsData.DBModels;

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
            List<GroupViewModel> groupsView = new List<GroupViewModel>();
            List<Group> groups = HomeController._dbContext.Groups.Include(x => x.GroupMembers).ToList();

            foreach (Group group in groups)
            {
                GroupViewModel g = new GroupViewModel()
                { 
                  GroupName = group.GroupName,
                  GroupId= group.GroupId,
                  GroupUsers = new List<User>(),
                };

                List<User> users = HomeController._dbContext.Users.Select(x => x).Where( x =>  group.GroupMembers.Select(z => z.GroupId).Contains(x.UserId)).ToList();
                g.GroupUsers.AddRange(users);
                groupsView.Add(g);
            }
            return View(groupsView);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.Submitted = false;

            if (HttpContext.Request.Method == "POST")
            {
                ViewBag.Submitted = true;
                var groupName = Request.Form["groupName"].ToString().TrimEnd();
                var members = Request.Form["members"];

                // Throw exception based on check
                if (string.IsNullOrWhiteSpace(groupName))
                    throw new Exception("Please make sure group name is populated.");

                if (HomeController._dbContext.Groups.Select(x => x.GroupName == groupName) != null)
                {
                    throw new Exception($"Group with the name {groupName} already exists.");
                }

                UsersGroupsData.DBModels.Group newGroup = new UsersGroupsData.DBModels.Group()
                {
                    GroupName = groupName,
                };

                HomeController._dbContext.Add(newGroup);
                if (HomeController._dbContext.SaveChanges() > 0)
                {
                    foreach (string memberid in members)
                    {
                        UsersGroupsData.DBModels.GroupMember groupMember = new UsersGroupsData.DBModels.GroupMember()
                        {
                            GroupId = newGroup.GroupId,
                            UserId = Convert.ToInt32(memberid)
                        };
                        HomeController._dbContext.Add(groupMember);
                    }

                    if (HomeController._dbContext.SaveChanges() > 0)
                    {
                        ViewBag.Message = " The group was created successfully.";
                    }
                }
                else
                {
                    ViewBag.Message = "There was an error while creating the group.";
                }

                return View();
            }

            var allUsers = HomeController._dbContext.Users.Select(x => x).ToList();
            return View(allUsers);
        }
    }
}
