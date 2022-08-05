using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Class
{
    [Table("TBL_User_Role_Match")]
    public class TBL_User_Role_Match
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TBL_RoleId { get; set; }
        public virtual TBL_Role TBL_Role { get; set; }
        public int TBL_UserId { get; set; }
        public virtual TBL_User TBL_User { get; set; }
    }
}
