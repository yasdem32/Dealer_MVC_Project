using Entities.ClassMyEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Class
{
    [Table("TBL_User")]
    public class TBL_User : MyEntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public Guid ActiveGuid { get; set; }

        public virtual List<TBL_User_Role_Match> tBL_User_Role_Matches { get; set; }

    }
}
