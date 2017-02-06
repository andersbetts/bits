using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class CustomerContact
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Phone Number 1")]
        [StringLength(100, MinimumLength = 2)]
        public string PhoneNumber_1 { get; set; }

        [Display(Name = "Phone Number 2")]
        [StringLength(100, MinimumLength = 2)]
        public string PhoneNumber_2 { get; set; }

        [Display(Name = "Email address 1")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress_1 { get; set; }

        [Display(Name = "Email address 2")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress_2 { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public bool Enabled { get; set; } = true;

    }
}
