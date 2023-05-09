///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: HackerRankLab
//	File Name: HackerRankSolution.cs   
//	Description: Answer to the "Closest Numbers" Problem on HackeRank.com. URL: https://www.hackerrank.com/challenges/closest-numbers/problem
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 8-17-20
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankLab
{
    /// <summary>Class containing a test driver and the answer to the problem: closestNumbers</summary>
    class HackerRankSolution
    {
        // Complete the closestNumbers function below.
        /// <summary>  Takes in a integer array, sorts them and then creates the closest pairs, based on the minimum difference between the values</summary>
        /// <param name="arr">  Array of 32-bit integers passed by the driver. This is given using file i/o on the website, hard coded in a sample array for the driver in my version.</param>
        /// <returns>resultArray: int[], array passed after the process is finished</returns>
        static int[] closestNumbers(int[] arr)
        {
            //initialize return values
            int[] resultArray;
            List<int> result = new List<int>();
            //sort array
            Array.Sort(arr);
            int minDiff = int.MaxValue;  //calculate the minimum difference by using the max value as a placeholder
            
            //iterate through to find the minimum difference
            for (int i = 1; i < arr.Length-1; i++)
            {
                if (Math.Abs(arr[i] - arr[i - 1]) < minDiff)    //check if the current minimum difference is larger than the current pair's
                                                                //min difference
                {
                    minDiff = Math.Abs(arr[i] - arr[i - 1]);      //if so, update the minimum difference
                }
            }
            for (int i = 1; i < arr.Length; i++)    //now iterate through to find values that adhere to the minimum difference
            {
                if (Math.Abs(arr[i] - arr[i - 1]) == minDiff)   //see if this pair adheres to the minimum difference
                {
                    //if so, add them to the list
                    result.Add(arr[i]);
                    result.Add(arr[i - 1]);
                }
            }

            //turn the list into an array and return
            resultArray = result.ToArray();
            Array.Sort(resultArray);
            return resultArray;

        }//end closestNumbers

        /// <summary>Defines the entry point of the application.
        /// Passes in a sample hard coded array, runs the closestNumbers method, and prints the results.</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            int[] arr = { -5,15,25,71,63};  //test array to initialize
            int[] result = closestNumbers(arr);     //run through the algorithm
            //print the results
            for(int i = 0; i<result.Length;i++)
            {
                Console.WriteLine(result[i].ToString());
            }
            Console.ReadLine();
        }//end main
    }//end HackerRankSolution
}
