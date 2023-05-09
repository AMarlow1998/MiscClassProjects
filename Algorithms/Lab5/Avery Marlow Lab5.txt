using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            List<Double> values = new List<Double>();
            List<Double> results = new List<Double>();
            List<String> valuesList = new List<String>();
            int valSize = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < valSize; i++)
            {
                String strInput = Console.ReadLine();
                valuesList.AddRange(strInput.Split(' '));
            }//end for
            
            for(int i = 0; i < valSize;i++)
            {
                values.Add(Double.Parse(valuesList[i]));
            }
            Stopwatch sw = Stopwatch.StartNew(); //create and start a stopwatch
            sw.Start();
           results = MergeSort(values);
            sw.Stop();
            Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
            for(int i = 0; i < results.Count;i++)
            {
                Console.WriteLine(results[i]);
            }

        }

        public static List<Double> Merge(List<Double> left, List<Double> right)
        {
            List<Double> results = new List<Double>();

            while(left.Count > 0 && right.Count > 0)
            {
                if(left[0] < right[0])
                {
                    results.Add(left[0]);
                    left.RemoveAt(0); //discard used value
                }
                else
                {
                    results.Add(right[0]);
                    right.RemoveAt(0); //discard used value
                }
                
            }//end while
            //add any remaining values to the list
            while(left.Count > 0)
            {
                results.Add(left[0]);
                left.RemoveAt(0);
            }
            while (right.Count > 0)
            {
                results.Add(right[0]);
                right.RemoveAt(0);
            }
            return results;
        }//end merge

        public static List<Double> Append(List<Double> left, List<Double> right)
        {
            List<Double> results = new List<Double>(left);
            foreach (double x in right)
                results.Add(x);
            return results;
        }
        public static List<Double> MergeSort(List<Double> list)
        {
            if (list.Count <= 1)
                return list;
            List<Double> results = new List<Double>();
            List<Double> left = new List<Double>();
            List<Double> right = new List<Double>();

            int mid = (list.Count / 2);
            for (int i = 0; i < mid; i++)
                left.Add(list[i]);
            for (int i = mid; i < list.Count; i++)
                right.Add(list[i]);
            //apply MergeSort to each half
            left = MergeSort(left);
            right = MergeSort(right);

            //if everything in the right sublist is greater than or equal to the left,
            //we need to append the right at the end to the left, which saves time
            if (left[left.Count - 1] <= right[0])
                return Append(left, right);

            //finally merge both results
            results = Merge(left, right);
            return results;
        }
    }
}
