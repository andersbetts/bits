using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class Currency
    {
        public int ID { get; set; }

        [StringLength(32, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string Acronym { get; set; }

        [StringLength(5, MinimumLength = 1)]
        public string Symbol { get; set; }

        public bool Enabled { get; set; }
    }
}
