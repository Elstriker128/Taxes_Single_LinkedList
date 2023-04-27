using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public sealed class LinkList<Type> : IEnumerable<Type> where Type : IComparable<Type>, IEquatable<Type>
    {
        /// <summary>
        /// A Node class that consists of two properties: the objects info and a direction towards the next object's information
        /// </summary>
        private sealed class Node<type>
        {
            public type Data { get; set; }
            public Node<type> Link { get; set; }
            /// <summary>
            /// A constructor for a Node object
            /// </summary>
            /// <param name="data">an object for the required type class</param>
            /// <param name="link">an object for the direction towards the next object's information</param>
            public Node(type data, Node<type> link)
            {
                Data = data;
                Link = link;
            }
        }
        private Node<Type> head;
        private Node<Type> tail;
        private Node<Type> current;
        /// <summary>
        /// A constructor for a LinkList<type> object
        /// </summary>
        public LinkList()
        {
            this.head = null;
            this.tail = null;
            this.current = null;
        }
        /// <summary>
        /// This constructor copies an existing linked list to a brand new one
        /// </summary>
        /// <param name="links">an object for the already existing linked list</param>
        public LinkList(LinkList<Type> links)
        {
            this.head = links.head;
            this.tail = links.tail;
            this.current = links.current;
        }
        /// <summary>
        /// This method adds the information of a singular object at the end of the linked list
        /// </summary>
        /// <param name="required">an object for the required type class</param>
        public void Add(Type required)
        {
            var gotten = new Node<Type>(required, null);
            if (head != null)
            {
                tail.Link = gotten;
                tail = gotten;
            }
            else
            {
                head = gotten;
                tail = gotten;
            }

        }
        /// <summary>
        /// This method returns the required type object's data
        /// </summary>
        /// <returns>the required type object's data</returns>

        public Type Get()
        {
            return current.Data;
        }
        /// <summary>
        /// This method places the primary value for the current variable that's going to bee used in calculations
        /// </summary>

        public void Begin()
        {
            current = head;
        }
        /// <summary>
        ///  This method gives the next value for the current variable using the linked list format
        /// </summary>

        public void Next()
        {
            current = current.Link;
        }
        /// <summary>
        /// This method checks if there are the upcoming value for the current variable is not null
        /// </summary>
        /// <returns>returns either true of false depending on if the upcoming value for the current variable is not null</returns>
        public bool Exist()
        {
            return current != null;
        }
        /// <summary>
        /// This method counts all the currently placed objects in the linked list
        /// </summary>
        /// <returns>the amount of currently placed objects in the linked list</returns>
        public int Count()
        {
            int count = 0;
            for (this.Begin(); this.Exist(); this.Next())
            {
                count++;
            }
            return count;
        }
        /// <summary>
        /// This method sorts the required objects in a linked list
        /// </summary>
        public void Sort()
        {
            for (Node<Type> d1 = head; d1 != null; d1 = d1.Link)
            {
                Node<Type> max = d1;
                for (Node<Type> d2 = d1; d2 != null; d2 = d2.Link)
                {
                    if (d1.Data.CompareTo(d2.Data) > 0)
                    {
                        max = d2;
                        Type Pr = d1.Data;
                        d1.Data = max.Data;
                        max.Data = Pr;
                    }
                }
            }
        }
        /// <summary>
        /// This method removes the required object from the linked list
        /// </summary>
        /// <param name="needed">an object of the required type class</param>
        public void Remove<other>(Type needed)
        {
            if (head == null)
            {
                return;
            }

            if (head.Data is other && head.Data.Equals(needed))
            {
                head = head.Link;
                return;
            }

            Node<Type> prev = head;
            while (prev.Link != null && !(prev.Link.Data is other && prev.Link.Data.Equals(needed)))
            {
                prev = prev.Link;
            }

            if (prev.Link != null)
            {
                prev.Link = prev.Link.Link;
            }
        }
        /// <summary>
        /// This method is required to realise the IEnumator add on and to realise a foreach cycle
        /// </summary>
        /// <returns>an IEnumerator<type> object</returns>
        public IEnumerator<Type> GetEnumerator()
        {
            for (Node<Type> dd = head; dd != null; dd = dd.Link)
            {
                yield return dd.Data;
            }
        }
        /// <summary>
        /// This method is also required to realise the IEnumator add on
        /// </summary>
        /// <returns>an exception</returns>
        /// <exception cref="NotImplementedException">this exception has not been implemented</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}