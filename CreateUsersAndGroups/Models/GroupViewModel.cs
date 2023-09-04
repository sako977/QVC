using UsersGroupsData.DBModels;

namespace CreateUsersAndGroups.Models
{
    public class GroupViewModel
    {
        public long GroupId { get; set; }

        public required string GroupName { get; set; }
        public List<User>? GroupUsers{ get; set; }
    }
}
