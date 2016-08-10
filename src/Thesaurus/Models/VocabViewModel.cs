using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thesaurus.Models
{
    public class VocabViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string term { get; set; }
    }
}
