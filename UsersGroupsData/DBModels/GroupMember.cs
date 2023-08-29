using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersGroupsData.DBModels
{
   public class GroupMember
   {
      public int GroupMemberId { get; set; }

      [ForeignKey("GroupId")]
      public long GroupId { get; set; }

      [ForeignKey("UserId")]
      public long UserId { get; set; }
   }
}
