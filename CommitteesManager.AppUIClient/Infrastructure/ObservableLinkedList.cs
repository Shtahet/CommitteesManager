using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    public class ObservableLinkedList<T> : INotifyCollectionChanged, IEnumerable
    {
        private LinkedList<T> _interiorLinkedList;

        public ObservableLinkedList()
        {
            _interiorLinkedList = new LinkedList<T>();
        }
        #region LinkedList Composition
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> retNode = _interiorLinkedList.AddAfter(node, value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            return retNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            _interiorLinkedList.AddAfter(node, newNode);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newNode));
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> retNode = _interiorLinkedList.AddBefore(node, value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            return retNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            _interiorLinkedList.AddBefore(node, newNode);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newNode));
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> retNode = _interiorLinkedList.AddFirst(value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            return retNode;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            _interiorLinkedList.AddFirst(node);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, node));
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> retNode = _interiorLinkedList.AddLast(value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value));
            return retNode;
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            _interiorLinkedList.AddLast(newNode);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newNode));
        }

        public void Clear()
        {
            _interiorLinkedList.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T value)
        {
            return _interiorLinkedList.Contains(value);
        }

        public bool Remove(T value)
        {
            bool retStatus = _interiorLinkedList.Remove(value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value));
            return retStatus;
        }

        public void Remove(LinkedListNode<T> node)
        {
            _interiorLinkedList.Remove(node);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, node));
        }

        public void RemoveFirst()
        {
            LinkedListNode<T> first = _interiorLinkedList.First;
            _interiorLinkedList.RemoveFirst();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, first));
        }

        public void RemoveLast()
        {
            LinkedListNode<T> last = _interiorLinkedList.Last;
            _interiorLinkedList.RemoveLast();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, last));
        }
        #endregion

        #region Accessors
        public int Count
        {
            get { return _interiorLinkedList.Count; }
        }

        public LinkedListNode<T> Find(T value)
        {
            return _interiorLinkedList.Find(value);
        }

        public LinkedListNode<T> FindLast(T value)
        {
            return _interiorLinkedList.FindLast(value);
        }

        public LinkedListNode<T> First
        {
            get { return _interiorLinkedList.First; }
        }

        public LinkedListNode<T> Last
        {
            get { return _interiorLinkedList.Last; }
        }
        #endregion

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_interiorLinkedList as IEnumerable)?.GetEnumerator();
        }
    }
}
