//Avery Marlow
//CSCI 3230
//Homework7.cs
// 10-24-2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Lab8
    {
        static void Main(string[] args)
        {
            //get user input
            string strInputA;
            string strInputB;
            Console.WriteLine("Please enter a string");
            strInputA = Console.ReadLine();
            Console.WriteLine("Please enter another string");
            strInputB = Console.ReadLine();
            //call and display
            int numMatches = FindLCS(strInputA, strInputB);
            Console.WriteLine("Matches " + numMatches);
            Console.ReadLine();
        }
        //finds the Least Common Substring between two strings by analyzing them character by character.
        static int FindLCS(string inputA, string inputB)
        {
            //declare return value
            int matches = 0;


            //store the lengths of each char array
            int lengthA = inputA.Length;
            int lengthB = inputB.Length;
            //count number of matches. 
            for (int i = 0; i < lengthA; i++)
            {
                for (int j = 0; j < lengthB; j++)
                {
                    if (inputA[i] == inputB[j]) //see if the character is the same
                    {
                            matches++; //then increment the matches
                     
                    }
                }
            }
            //return number of matches
            return matches;

        }
    }
}