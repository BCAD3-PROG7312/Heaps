using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps.PQueues
{
   public class CNode<T>
    {
        public T data;

        public int priority;

        public CNode()
        {
            // default constructor
        }

        public CNode(T data, int priority)
        {
            this.data = data;
            this.priority = priority;
        }
    }
}
