using System;
using System.Collections.Generic;
using System.Text;

namespace _11.LinkedListDynamic
{
    public class DynamicList<T>
    {
        private class DoubleLinkedListNode
        {
            public T Element { get; set; }

            public DoubleLinkedListNode NextNode { get; set; }

            public DoubleLinkedListNode PreviousNode { get; set; }

            public DoubleLinkedListNode(T element, DoubleLinkedListNode nextNode, DoubleLinkedListNode previousNode)
            {
                this.Element = element;
                this.NextNode = nextNode;
                this.PreviousNode = previousNode;
            }

            public DoubleLinkedListNode(T element)
            {
                this.Element = element;
                this.NextNode = null;
                this.PreviousNode = null;
            }
        }

        private DoubleLinkedListNode head;
        private DoubleLinkedListNode tail;
        private int count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new DoubleLinkedListNode(item);
                this.tail = this.head;
            }
            else
            {
                DoubleLinkedListNode newNode = new DoubleLinkedListNode(item, tail);
            }
        }
    }
}
