using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class Tag
    {

        public int ID { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Name { get; set; }

        public bool Enabled { get; set; }
    }
}
