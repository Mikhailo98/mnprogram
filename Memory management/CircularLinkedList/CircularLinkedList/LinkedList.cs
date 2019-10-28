using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CircularLinkedList;

[assembly: InternalsVisibleTo("CircularLinkedListTest")]
namespace CustomCollection.Generic
{
    public class LinkedList<T> : ILinkedList<T>
    {
        internal Node<T> Head { get; set; }
        public int Length { get; private set; }

        public T this[int index]
        {
            get => ElementAt(index);
            set => SetValue(index, value);
        }

        public LinkedList() { }


        public LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                Add(item);
        }


        public void Add(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
                InsertIntoEmptyCollection(newNode);
            else
                InsertBeforeNode(Head, newNode);
        }


        public void AddAt(int index, T data)
        {
            var newNode = new Node<T>(data);
            var node = FindNode(index);

            if (node == null)
            {
                InsertIntoEmptyCollection(newNode);
            }
            else
            {
                InsertBeforeNode(node, newNode);
                if (index == 0)
                    Head = newNode;
            }
        }


        public T ElementAt(int index)
        {
            if (Head == null)
                throw new InvalidOperationException("Can't get element of null");

            return FindNode(index).Value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public T RemoveAt(int index)
        {
            var nodeToDelete = FindNode(index);
            RemoveNode(nodeToDelete);
            return nodeToDelete.Value;
        }


        public T Remove()
        {
            if (Head == null)
                throw new InvalidOperationException("Can't delete element of null");

            var nodeToDelete = Head.Previous;
            RemoveNode(nodeToDelete);
            return nodeToDelete.Value;
        }


        private void RemoveNode(Node<T> nodeToDelete)
        {
            if (nodeToDelete == Head && Head.Previous == Head)
            {
                Head = null;
            }
            else
            {
                nodeToDelete.Previous.Next = nodeToDelete.Next;
                nodeToDelete.Next.Previous = nodeToDelete.Previous;

                if (nodeToDelete == Head)
                    Head = Head.Next;
            }

            Length--;
        }


        private void InsertIntoEmptyCollection(Node<T> newNode)
        {
            Head = newNode;
            Head.Previous = Head;
            Head.Next = Head;
            Length++;
        }


        private void InsertBeforeNode(Node<T> currentNode, Node<T> newNode)
        {
            newNode.Previous = currentNode.Previous;
            newNode.Next = currentNode;
            currentNode.Previous.Next = newNode;
            currentNode.Previous = newNode;
            Length++;
        }


        private void SetValue(int index, T value)
        {
            var node = FindNode(index);
            node.Value = value;
        }


        private Node<T> FindNode(int index)
        {
            if (Length < index)
                index = index % Length;

            Func<Node<T>, Node<T>> func = node => node.Next;

            if (Length / 2 < index)
            {
                func = node => node.Previous;
                index = Length % index;
            }

            var current = Head;
            for (var i = 0; i < index; ++i)
                current = func.Invoke(current);

            return current;
        }
    }
}