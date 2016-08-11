using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thesaurus.Models
{
    public interface IRepository
    {
        IEnumerable<Vocabulary> GetVocab();
        Vocabulary GetAssociatedVocab(string vocab);
        void AddVocab(Vocabulary newTerm);
        void AddContextTerm(string vocab, ContextTerm newContextTerm);
        Task<bool> SaveChangesAsync();
        
    }
}