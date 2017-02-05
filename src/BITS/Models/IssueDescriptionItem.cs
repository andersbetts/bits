using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models
{
    public class IssueDescriptionItem
    {
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? ParentID { get; set; }
        public virtual IssueDescriptionItem Parent { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9''-' \s]*$")]
        public string  Name { get; set; }

        public bool Enabled { get; set; }

        public virtual ICollection<IssueDescriptionItem> Children { get; set; }
    }
}
