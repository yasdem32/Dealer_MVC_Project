using Entities.ClassMyEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Class
{
    [Table("TBL_Role")]
    public class TBL_Role : MyEntityBase
    {
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual List<TBL_User_Role_Match> tBL_User_Role_Matches { get; set; }
    }
}
