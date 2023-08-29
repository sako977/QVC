using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersGroupsData.DBModels
{
   public class Group
   {
      public long GroupId { get; set; }

      public required string  GroupName { get; set; }

      public virtual ICollection<GroupMember> GroupMembers { get; set; }
   }
}
