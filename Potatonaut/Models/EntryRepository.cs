using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public class EntryRepository : IEntryRepository
    {
        private AppDbContext _context;

        public EntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Entry> GetAllEntries()
        {
            var _entries = _context.Entries.ToList<Entry>();
            return _entries;
        }

        public Entry GetEntryById(int entryId)
        {
            throw new NotImplementedException();
        }
    }
}
