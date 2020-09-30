using Heaps.PQueues;
using PQueues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heaps
{
    public partial class Form1 : Form
    {

        Heap heap = new Heap();
        PriorityQueue priorityQueue = new PriorityQueue();
       GPQ<Person> generic = new GPQ<Person>();
       
        public Form1()
        {
            InitializeComponent();

            //heap.iadd(5);
            //heap.iadd(20);
            //heap.iadd(3);
            //heap.iadd(80);
            //heap.iadd(1);
            //int peeked = heap.peek();
            //int polled =  heap.poll();
            //int peekedAgain = heap.peek();

            //priorityQueue.Enqueue(1100, 8);
            //priorityQueue.Enqueue(5000, 1);
            //priorityQueue.Enqueue(15252, 0);

           
            generic.Enqueue(new Person { age = 5, Name = "peter", Address = "who cares" },80);
            generic.Enqueue(new Person { age = 5, Name = "Paul", Address = "who cares" }, 1);
            generic.Enqueue(new Person { age = 5, Name = "Michael", Address = "who cares" }, 3);



            //for (int i = 0; i <= 2; i++)
            //{
            //    MessageBox.Show(priorityQueue.Dequeue().data.ToString());
            //}

            for (int j = 0; j < 4; j++)
            {
                MessageBox.Show(generic.Dequeue().data.Name);
            }

        }
    }
}
