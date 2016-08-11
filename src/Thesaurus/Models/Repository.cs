using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thesaurus.Data;

namespace Thesaurus.Models
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;

        }

        public void AddContextTerm(string vocab, ContextTerm newContextTerm)
        {
            var vocabTerm = GetAssociatedVocab(vocab);

            if(vocabTerm != null)
            {
                vocabTerm.contextTerms.Add(newContextTerm);
                _context.ContextTerm.Add(newContextTerm);
            }
        }

        public void AddVocab(Vocabulary newTerm)
        {
            _context.Add(newTerm);
        }
        //Here is one of the missing pieces
        public Vocabulary GetAssociatedVocab(string vocab)
        {
            return _context.Vocabulary
                .Include(v => v.contextTerms)
                .Where(v => v.term == vocab)
                .FirstOrDefault();
        }

        public IEnumerable<Vocabulary> GetVocab()
        {
            return _context.Vocabulary.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
    