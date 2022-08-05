using Entities.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext :DbContext
    {
        public DbSet<TBL_Role> TBL_Role { get; set; }
        public DbSet<TBL_User> TBL_User { get; set; }
        public DbSet<TBL_User_Role_Match> TBL_User_Role_Match { get; set; }
        public DbSet<TBL_Audit> TBL_Audit { get; set; }
    }
}
