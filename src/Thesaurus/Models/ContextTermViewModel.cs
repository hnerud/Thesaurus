using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thesaurus.Models
{
    public class ContextTermViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string term { get; set; }
        public string type { get; set; }
    }
}
