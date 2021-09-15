
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace C101A.InMemory.Api.Helpers
{
    public static class CollectionsExtensions
    {
        public static Dictionary<T, K> HashtableToDictionary<T, K>(this Hashtable table)
        {
            return table
              .Cast<DictionaryEntry>()
              .ToDictionary(kvp => (T)kvp.Key, kvp => (K)kvp.Value);
        }
    }
}
