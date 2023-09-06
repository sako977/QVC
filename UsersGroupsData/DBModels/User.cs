using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersGroupsData.DBModels
{
   public class User
   {
      public long UserId { get; set; }

      public required string FirstName { get; set; }

      public required string LastName { get; set; }

      public required string Email { get; set; }

      public required ushort Age { get; set; }

      public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
