using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CircularLinkedList;

namespace CustomCollection.Generic
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly LinkedList<T> _list;
        private Node<T> _node;

        object IEnumerator.Current => _node.Value;
        public T Current => _node.Value;


        public LinkedListEnumerator(LinkedList<T> list)
        {
            _node = list.Head;
            this._list = list;
        }


        public bool MoveNext()
        {
            if (_node == null)
                return false;

            _node = _node.Next;

            if (_node == _list.Head)
                _node = null;

            return true;
        }


        public void Reset()
        {
            _node = _list.Head;
        }


        public void Dispose() { }
    }
}