using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Adapter
{
    public class Elements<T> : IElements<T>
    {
        private readonly List<T> _list;

        public Elements(IEnumerable<T> elements)
        {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            _list = elements.ToList();
        }

        public IEnumerable<T> GetElements()
        {
            return _list;
        }
    }
}