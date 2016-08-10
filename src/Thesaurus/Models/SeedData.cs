using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thesaurus.Data;

namespace Thesaurus.Models
{
    public class SeedData
    {
        private ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task EnsureSeedData()
        {
            if (_context.Vocabulary.Any())
            {
                return;
            }
            var vocab = new Vocabulary();
                {
                    vocab.term = "idyllic";

                    vocab.contextTerms = new List<ContextTerm>()
                    {
                        new ContextTerm() {term = "pleasant", type = "basic"},

                        new ContextTerm() {term = "bucolic", type = "advanced"}

                    };
                };
                _context.Vocabulary.Add(vocab);
                _context.ContextTerm.AddRange(vocab.contextTerms);

                var morevocab = new Vocabulary();
                {
                    morevocab.term = "conformity";

                    morevocab.contextTerms = new List<ContextTerm>()
                {
                    new ContextTerm() {term = "same", type = "basic"},

                     new ContextTerm() {term = "accordance", type = "advanced"}


                };
                };
                _context.Vocabulary.Add(morevocab);
                _context.ContextTerm.AddRange(morevocab.contextTerms);

                await _context.SaveChangesAsync();
            
        }
    }
}
