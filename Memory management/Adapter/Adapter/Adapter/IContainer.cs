using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    public interface IContainer<T>
    {
        IEnumerable<T> Items { get; }
        int Count { get; }
    }
}