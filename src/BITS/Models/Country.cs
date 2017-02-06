using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class Country
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string ISOAlpha3 { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public bool Enabled { get; set; } = true;

        [StringLength(10)]
        public string PhonePrefix { get; set; }
    }
}
