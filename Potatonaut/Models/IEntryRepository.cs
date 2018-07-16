using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Potatonaut.Models
{
    public interface IEntryRepository 
    {
        IEnumerable<Entry> GetAllEntries();
        Entry GetEntryById(int entryId);
    }
}
