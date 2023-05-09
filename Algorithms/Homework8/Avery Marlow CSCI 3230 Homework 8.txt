using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            //take input in to make the heap
            String strInput;
            int iSize = int.Parse(Console.ReadLine());
            MaxHeap heap = new MaxHeap(iSize);
            for (int i = 0; i < iSize; i++)
            {
                strInput = Console.ReadLine();
                heap.Insert(strInput);
            }
            //sort heap and print the result
            heap.HeapSort();
            heap.PrintArray();
            Console.ReadLine();
        }
    }
    //manage a maxheap and its several properties
    public class MaxHeap
    {
        //declare the current and max sizes of the heap and the heap itself
        private int max_size;
        private int size;
        private string[] h;
        
        //constructs a new heap
        public MaxHeap(int totalSize)
        {   
            //initialize the size, the heap, and the maximum heap size
            size = 0;
            max_size = totalSize + 1;   //initialize to plus 1 for ease of counting and debugging 
            h = new string[max_size];

        }
        //return the position of the leftmost child given a parent
        private int GetLeftChildPos(int parent)
        {
            int intPos = 2 * parent; //formula for finding left child
            //if the position is not in the heap, return 0
            if(intPos > size)
            {
                return 0;
            }
            return intPos;
        }
        //return the position of the rightmost child given a parent
        private int GetRightChildPos(int parent)
        {
            int intPos = 2 * parent+1;  //formula for finding right child
            //if the position is not in the heap, return 0
            if (intPos > size)
            {
                return 0;
            }
            return intPos;
        }
        //see if the position that we are at has no children
        public Boolean CheckForLeaf(int pos)
        {
            if(pos > size/2 && pos< size)
            {
                return true;
            }
            return false;
        }
        //print out the contents of the heap, not necessarily the whole heap
        public void Print()
        {
            string strHeap = " ";
            for (int i = 1; i < size+1; i++)
            {
                strHeap +="\t" + h[i];
            }
            Console.WriteLine(strHeap);
        }
        //sorts the array by extracting values off the top of the heap
        public void HeapSort()
        {
            for (int i = 0; i < max_size-2; i++)    //have to do -2 because we originally add 1 to max_size
                                                    //and we need to subtract 1 to keep the index in bounds.
            {
                ExtractMax();
                //Print();
                //PrintArray();

            }
        }
        //prints the entire array, ignoring what's in the heap.
        public void PrintArray()
        {
            
            for (int i = 1; i < h.Length; i++)
            {
                Console.WriteLine(h[i]);
            }
            
        }
        //switch two values in the heap given two positions.
        public void HeapSwitch(int valA, int valB)
        {
            string temp;
            temp = h[valA];
            h[valA] = h[valB];
            h[valB] = temp;
        }
        //insert 1 value in the heap,and then correct the input to satisfy the heap property.
        public void Insert(string Item)
        {
            string temp;
            if (size != max_size)
            {
                size++;
                h[size] = Item;

                int currentPos = size;
                //switch the parent and child around as long as the comparison returns 1. 
                //Alternatively, switch if the current position is not the root.
                while (String.CompareOrdinal(h[currentPos / 2], h[currentPos]) > 0 || currentPos != 1)
                {
                    HeapSwitch(currentPos, currentPos / 2);
                    currentPos = currentPos / 2;
                }

            }

        }
        //extract the top value of the heap, decrement its size, and then maintain the heap property
        public void ExtractMax()
        {
            HeapSwitch(1, size);
            size--;
            maintainHeap(1);
        }
        //method to preserve the heap property.
        public void maintainHeap(int startingPos)
        {
            //return immediately if the starting position has no children
            if(CheckForLeaf(startingPos) == true)
            {
                return;
            }
            //see if the children are greater than the parent
            if(String.CompareOrdinal(h[startingPos], h[GetLeftChildPos(startingPos)]) < 0
                || String.CompareOrdinal(h[startingPos], h[GetRightChildPos(startingPos)]) < 0)
            {
                //then see if the left child is greater than the right child.
                if (String.CompareOrdinal(h[GetLeftChildPos(startingPos)], h[GetRightChildPos(startingPos)]) > 0)
                {
                    //if this is true then switch the parent and the left child's locations
                    HeapSwitch(startingPos, GetLeftChildPos(startingPos));
                    //then maintain the heap property  
                    maintainHeap(GetLeftChildPos(startingPos));

                }
                else
                {
                    //otherwise switch the parent and the right child
                    HeapSwitch(startingPos, GetRightChildPos(startingPos));
                    //then maintain heap property
                    maintainHeap(GetRightChildPos(startingPos));
                }
                
            }
            


        }
    }
}
