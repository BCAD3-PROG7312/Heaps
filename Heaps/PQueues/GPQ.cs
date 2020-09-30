using Heaps.PQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PQueues
{
    public class GPQ<T>
    {
        private static  int capacity = 10;
        private int size = 0;
        public CNode<T> [] items = new CNode<T>[capacity]; // we now use an array of nodes instead of ints

        // get the indexes of where parents and children are stored in the array 
        private int getleftChildIndex(int parentIndex)
        {
            return (2 * parentIndex) + 1;
        }

        private int getRightChildIndex (int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex (int childIndex)
        {
            return (childIndex - 1) / 2;
        }
        // check if Node has any parents or children
        private bool hasLeftChild(int index)
        {
            return getleftChildIndex(index) < size;
        }

        private bool hasRightChild (int index)
        {
            return getRightChildIndex(index) < size;
        }

        private bool hasParent (int index)
        {
            return getParentIndex(index) >= 0;
        }

        // return the values of the actual children or parents

        //Change to node becuase we are now working with an arry of nodes
        private CNode<T> leftChild (int index)
        {
            return items[getleftChildIndex(index)];
        }

        private CNode<T> rightChild (int index)
        {
            return items[getRightChildIndex(index)];
        }

        private CNode<T> parent (int index)
        {
            return items[getParentIndex(index)];
        }

        // our swop method that will work with heapify up and down to order our heap after insertions or deletions

        private void swap (int indexOne, int indexTwo)
        {
            CNode<T>temp = items[indexOne];// store index one in a temp value 
            items[indexOne] = items[indexTwo]; // swap the  values that was in indes one with index two 
            items[indexTwo] = temp; // set the correct value (old one) to index two 
            //boom we swopped stuff!!!
        }

        // method to copy our data to a new array double the size of the old one gets full 
        private void ensureExtraCapacity()
        {
            if(size == capacity)
            {
                
                Array.Copy(items, items, (capacity*2));
                capacity *= 2;
            }

        }

        public int peek()
        {
            if (size == 0)
            {
                MessageBox.Show("Array is empty you Doffie");
                throw new NullReferenceException();
               
            }
            else
            {
                return items[0].priority; // we now return the priority value as this r
            }
        }

        public CNode<T> Dequeue() // luck pop but for heaps 
        {
            if (size == 0)
            {
                throw new NullReferenceException();
            }
            else 
            {
                // get value
                CNode<T> item = items[0];
                items[0] = items[size - 1]; // move very last element of array to top 
                size--; //shrink array
                heapifyDown();
                return item;
            }
        }

        public void Enqueue (T item, int priority)
        {
            ensureExtraCapacity(); // check that we have space to add an item, make if we dont 
                                   //add element to last spot 
                                   // items[size].priority = item;
            items[size] = new CNode<T>(item, priority);
            //grow array 
            size++;
            heapifyUp();
        }

        public void heapifyUp()// when we add 
        {
            //start with last element added to array 
            int index = size - 1;
            //walk up the list as long as you have parents  and if the are out of order.... Batman cant have no heap 

            while (hasParent(index) && parent(index).priority> items[index].priority) // do I have a parent and are they bigger than me ?
            {
                //swap parent index
                swap(getParentIndex(index), index); //swop my value with my parent
                //then walk upwards (check the next parent and child)
                index = getParentIndex(index);
            }

        }

        public void heapifyDown() // when we delete
        {
            // start at the top 
            int index = 0;
            // children are added left to rignt - now left child == no right child 
            while (hasLeftChild(index))
            {
                // create int value smaller index and set to left child for now
                int smallerChildIndex = getleftChildIndex(index);
                // next check if we have a right child AND check if it is smaller than the left child 
                if (hasRightChild(index) && rightChild(index).priority < leftChild(index).priority)
                {
                    smallerChildIndex = getleftChildIndex(index); // set smallerChild to right only if it is smaller than right
                }

                if (items[index].priority < items[smallerChildIndex].priority)
                    break;
                else
                {
                    swap(index, smallerChildIndex);
                    
                }

                index = smallerChildIndex;

            }
        }
    


    }
}
