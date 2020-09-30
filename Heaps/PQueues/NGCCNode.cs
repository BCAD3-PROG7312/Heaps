using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps.PQueues
{
   public class NGCCNode
    {
        public int data;

        public int priority;

        public NGCCNode()
        {
            // default constructor
        }

        public NGCCNode(int data, int priority)
        {
            this.data = data;
            this.priority = priority;
        }
    }
}
