///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: SphereTestSolution
//	File Name: SphereTestSolution.cs   
//	Description: Answer to the "Life, Universe, Everything" Problem on SPOJ.com. URL: https://www.spoj.com/problems/TEST/
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 8-17-20
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereTests
{
    /// <summary>Method handling the answer to question of SPOJ</summary>
    class SphereTestSolution
    {
        /// <summary>Defines the entry point of the application.
        /// To find 42, we simply accept input from the website, and when 42 is found, we stop processing input</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //check for a 42 given by the user
           while(true)
            {
                int answer;
                answer = int.Parse(Console.ReadLine()); //get input
                if (answer == 42)   //check if the input is 42
                    break;  //if so, break
                Console.WriteLine(answer);  //otherwise, print the value
            }//end while
            
          
        }//end main
    }
}
