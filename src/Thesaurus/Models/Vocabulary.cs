using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Thesaurus.Models
{
    public class Vocabulary
    {
        public int ID { get; set; }
        
        public string term { get; set; }
        public virtual ICollection<ContextTerm> contextTerms { get; set; }
        public string imagePath { get; set; }
    }
}
