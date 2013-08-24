using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMe.NodeTypes
{
    public class SinglyLinkedNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedNode<T> Next { get; set; }

        public SinglyLinkedNode()
        {
            Data = default(T); //we use default to set a generic to a value or else we get an error
            Next = null; //null is our end-of-list marker
        }

        public SinglyLinkedNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
