///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Lab 4- Recursion
//	File Name:		Lab4.cs
//	Description:	Answers for solving a few cases in recursion. Example work of Master's Method and Divide and Conquer 
//	Course:			CSCI 3230
//	Author:			Avery Marlow, marlowas@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		9-20-2020
//	Copyright:		Avery Marlow, marlowas@etsu.edu
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Lab4
    {
        static void Main(string[] args)
        {   //store values used in assignment + the number of steps
            int input;
            double largeValue;
            int step = 0;
            //get input from user
            Console.WriteLine("Please give an integer n to find its value");
            input = Int32.Parse(Console.ReadLine());
            //define stopwatch, begin testing functions
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //largeValue = Fibonacci(input);
            //largeValue = Pow(input, ref step);
            //largeValue = Pow2(input, ref step);
            largeValue = Pow3(input, ref step);
            sw.Stop();
            //print results
            Console.WriteLine("The modified value of n = " + input.ToString() + " returned " + largeValue.ToString());
            Console.WriteLine("Steps taken: {0}", step);
            Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();
        }
        public static double Fibonacci(int val)
        {
            if(val == 0)
            {
                return 0;
            }
            else if(val == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(val - 1) + Fibonacci(val - 2);
            }
        }
        //T(N) = T(N-1)+2
        public static double Pow(int n, ref int step, int x = 1)
        {
            
            if(n == 1)
            {
                //1 step
                step++;
                return 1;
            }
            else
            {
                //1 step
                step++;
                return Pow(n - 1, ref step,x) * x;
            }
            
        }
        //2T(N/2)+2
        public static double Pow2(int n, ref int step,int x = 1)
        {
            if (n == 1)
            {   
                //1 step
                step++;   
                return 1;
            }
            else
            {
                //2 steps
                step += 2;
                return Pow2((n/2), ref step,x) * Pow2((n/2), ref step,x);
            }
        }
        //T(N) = T(N/2)+C, where C is dependent on whether N is even or odd
        public static double Pow3(int n,ref int step, int x = 1)
        {
            if (n == 1)
            {
                //step
                step++;
                return 1;
            }
            else if(n % 2 == 0)
            {
                //step+2
                step += 2;
                double temp = Pow3((n / 2), ref step, x);
                return temp * temp;
            }
            else
            {
                //3 steps
                step += 3;
                double temp = Pow3((n / 2), ref step, x);
                return (temp*temp)*x;
            }
        }

    }
}
