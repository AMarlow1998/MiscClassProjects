///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: Lab 3
//	File Name: Lab 3.cs
//	Description: Experimenting with data structures.
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 9-14-20
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Lab3Driver
    {
        static void Main(string[] args)
        {
            int iNumLines = Int32.Parse(Console.ReadLine());
            String[] stringArray = new string[iNumLines];
            LinkedList<String> stringLL = new LinkedList<string>();
            List<String> stringList = new List<string>();
            HashSet<String> stringHash = new HashSet<string>();
            SortedSet<String> stringSet = new SortedSet<String>();
            Dictionary<String,int> strDictionary = new Dictionary<String,int>();
            int uniqueValues = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i< iNumLines-1;i++)
            {
                //stringArray[i] = Console.ReadLine();
                //stringHash.Add(Console.ReadLine());
                //stringLL.AddLast(Console.ReadLine());
                //stringList.Add(Console.ReadLine());
                //stringSet.Add(Console.ReadLine());
                //for dictionary
                if (Console.ReadLine() == null)
                {
                    break;
                }
                strDictionary.TryGetValue(Console.ReadLine() ?? string.Empty, out int value);
                strDictionary[Console.ReadLine() ?? string.Empty] = value + 1;
                

            }
            //Sort and clean out duplicates.
            //  Array.Sort(stringArray, StringComparer.Ordinal);
            //stringArray = stringArray.Distinct().ToArray();
            //cannot sort a hashset, there are also no duplicates allowed in hashset
            //stringList = stringList.Distinct().ToList();
            //stringList.Sort();
            //List<String> stringLList = stringLL.Distinct().ToList();
            //stringLList.Sort();
            //sortedSet cannot have duplicates

            sw.Stop();
            //iNumLines = stringArray.Length;
            //iNumLines = stringHash.Count;
            //iNumLines = stringList.Count;
            //iNumLines = stringSet.Count;
            //iNumLines = stringLList.Count();
           Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
           //Console.WriteLine("Number of Lines: " + iNumLines);
            for (int i = 0; i < iNumLines-1; i++)
            {
                //Console.WriteLine(stringArray[i]);
                //Console.WriteLine(stringHash.ElementAt(i));
                //Console.WriteLine(stringList[i]);
                //Console.WriteLine(stringLList[i]);
                //Console.WriteLine(stringSet.ElementAt(i);
            }
            //for counting dictionary values
            for(int i = 0; i<strDictionary.Count();i++)
            {
                uniqueValues++;
            }
            Console.WriteLine("There are " + uniqueValues.ToString() + " unique values in the dictionary"); 



        }
    }
}
