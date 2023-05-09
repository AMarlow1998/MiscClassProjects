using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            String strInput = " ";
            Console.WriteLine("How many strings are we placing in the heap?");
            int iSize = int.Parse(Console.ReadLine());
            MaxHeap heap = new MaxHeap(iSize);
            for(int i = 0; i< iSize;i++)
            {
                Console.WriteLine("Please give a string to put in the heap");
                strInput = Console.ReadLine();
                heap.Insert(strInput);
            }
            heap.Print();
            Console.ReadLine();
        }
    }
    public class MaxHeap
    {
        private int max_size;
        private int size;
        private string[] h;
        public MaxHeap()
        {

        }
        public MaxHeap(int totalSize)
        {
            size = 0;
            max_size = totalSize+1;
            h = new string[max_size];

        }
        public void Print()
        {
            for(int i = 1; i<h.Length;i++)
            {
                Console.WriteLine("\t"+h[i]);
            }
        }
        public void Insert(string Item)
        {
            string temp;
            if (size != max_size)
            {
                size++;
                h[size] = Item;
                
                int currentPos = size;
                while (String.CompareOrdinal(h[currentPos/ 2], h[currentPos]) > 0 || currentPos !=1)
                {
                    temp = h[currentPos];
                    h[currentPos] = h[currentPos / 2];
                    h[currentPos / 2] = temp;
                    currentPos = currentPos / 2;
                }
                    
            }
               
        }
    }
}
