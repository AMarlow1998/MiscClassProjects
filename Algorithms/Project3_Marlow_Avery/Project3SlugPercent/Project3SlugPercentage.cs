///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: Project3: Slug Percentage
//	File Name: Project3SlugPercentage.cs
//	Description: Calculates the batting average of a baseball player.
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 11-12-2020
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project3SlugPercent
{
    class Project3SlugPercentage
    {
        /// <summary>Defines the entry point of the application.
        /// Takes user's input, either through a file or manual input, and the calculates the slugging percentage</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            string strStats;    //stores the stats as input by the user
            double topTotal =0; //initialize the sum of the stats
            //prompt and get input from user for the number of times the player was at bat
            Console.WriteLine("\tHow many times was the player at bat?");
            int numbats = Int32.Parse(Console.ReadLine());
            double[] stats = new double[numbats];   //will store the actual floating point variant of the stats
            //prompt the user to input the player's stats
            Console.WriteLine("\tEnter the results of the player with a number, separated by a space " +
                "\n\t1-3: Single, Double, Triple; respectively" +
                "\n\t  4: Home Run" +
                "\n\t  0: Strike-Out" +
                "\n\t -1: Walk");
            strStats = Console.ReadLine();
            string[] slugstats = strStats.Split(' ');   //store the stats in a string array after splitting them one by one
            //start placing the values from slug stats into the double array
            for (int i = 0; i < stats.Length; i++)
            {   
                //take the value from the string array
                int placeholder = Int32.Parse(slugstats[i]);
                //check if its a walk and decrement the number of bats if it is one
                if(placeholder == -1)
                {
                    numbats--;
                    continue;
                }
                //then place any non walks into the double array
                stats[i] = Int32.Parse(slugstats[i]);
                //while doing this, the accepted values as the total
                topTotal += stats[i];
            }
            //slugging percentage is accepted as the total of the player's results divided by the number of times the player was at bat
            double result = topTotal / numbats;
            //print the result
            Console.WriteLine("\tThe batting percentage is "+result);
            Console.ReadLine();
        }//end main
    }
}
