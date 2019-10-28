namespace CustomHashTable
{
    public interface IHashTable<in TKey, TValue>
    {
        int Count { get; }
        TValue this[TKey key] { get; set; }

        bool Contains(TKey key);
        void Add(TKey key, TValue value);
        bool TryGet(TKey key, out TValue value);
    }
}