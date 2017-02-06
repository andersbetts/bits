using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class Customer
    {
        public int ID { get; set; }

        /// <summary>
        /// High-level id. Not for the database, but what is used in 3rd party systems
        /// </summary>
        public string IDNumber { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Address 1")]
        [StringLength(100)]
        public string Address_0 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(100)]
        public string Address_1 { get; set; }

        [Display(Name = "Address 3")]
        [StringLength(100)]
        public string Address_2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        public int CountryID { get; set; }
        public Country Country { get; set; }

        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public bool Enabled { get; set; } = true;

    }
}
