using System.Collections.Generic;

namespace CustomCollection.Generic
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        int Length { get; }
        T this[int index] { get; set; }

        void Add(T data);
        void AddAt(int index, T data);
        T Remove();
        T RemoveAt(int index);
        T ElementAt(int index);
    }
}