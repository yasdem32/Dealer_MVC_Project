﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ClassMyEntity
{
    public class MyEntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required]
        public DateTime CreatedOnByDate { get; set; }
        [Required]
        public DateTime ModifiedOnByDate { get; set; }
        [Required]
        public string ModifiedUserName { get; set; }
    }
}
