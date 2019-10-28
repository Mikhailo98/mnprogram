using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class DuplicateKeyException<TKey> : ArgumentException
    {
        public DuplicateKeyException(TKey key)
            : base($"Such key: {key.ToString()}, already exists;") { }
    }
}
