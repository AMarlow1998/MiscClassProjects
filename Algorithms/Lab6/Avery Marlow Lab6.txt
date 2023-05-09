///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: Lab6
//	File Name: Lab6.cs   
//	Description: Answer to the Closest Pair Problem on SPOJ.com URL: https://www.spoj.com/problems/CPP/
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 9-10-20
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab6
{
    class Lab6
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
            List<String> valuesList = new List<String>();
            double dDistance;
            int index = 0;
            //get items from input
            int valSize = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < valSize; i++)
            {
                String strInput = Console.ReadLine();
                valuesList.AddRange(strInput.Split(' '));
            }//end for
            //parse into output list
            for (int i = 0; i < valSize; i++)
            {
                int placeholder = Int32.Parse(valuesList[index]);
                index++;
                int placeholder2 = Int32.Parse(valuesList[index]);
                points.Add(new Point(placeholder, placeholder2));
                index++;
            }
            //convert list to array and sort
            Point[] pointX = points.ToArray();
            Array.Sort(pointX, new PointCompareByX());
            Stopwatch sw = Stopwatch.StartNew(); //create and start a stopwatch
			//call cpp solver
            dDistance = SolveClosestPoints(pointX, valSize);
            Console.WriteLine("The distance between the closest pairs is: " + Math.Round(dDistance, 6)); //print the distance that we calculated 
            sw.Stop();      //stop the stopwatch
            Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000); //print the elapsed time
            Console.ReadLine();

        }
        //method for solving CPP
        private static double SolveClosestPoints(Point[] pointArray, int valSize)
        {
			//create values for the first and second halves of the array, as well as the midpoint
            double dFirst;
            double dSecond;
            double dHalfMin;
            List<Point> strip = new List<Point>();
            double minStripDist = double.MaxValue;
            //if n is less than or equal to 5 we consider it small enough to brute force
            if(valSize <= 5)
            {
                return BruteForceCP(pointArray, valSize);
                
            }
            //otherwise half the contents of n and then recursively call the for each half of n
            Point[] firstHalf = pointArray.Take(pointArray.Length / 2).ToArray();
            Point[] secondHalf = pointArray.Skip(pointArray.Length / 2).ToArray();
            dFirst =  SolveClosestPoints(firstHalf, firstHalf.Length);
            dSecond = SolveClosestPoints(secondHalf, secondHalf.Length);
            //check between each half to see what the minimum value is
            if (dFirst < dSecond)
            {
                dHalfMin = dFirst;
            }
            else
                dHalfMin = dSecond;
            //create the strip of points based off the middle of the array that may have not been accounted for
            for (int i = 0; i < valSize - 1; i++)
            {
                double dist = FindDistance(pointArray[i], pointArray[pointArray.Length / 2]);
                if(dist < dHalfMin)
                {
                    strip.Add(pointArray[i]);
                }

            }
            //calculate the distance of the strip
            Point[] stripArray = strip.ToArray();
            Array.Sort(stripArray, new PointCompareByY());
            for(int i = 0; i<stripArray.Length;i++)
            {
                for (int j = i + 1; j < stripArray.Length && j < i + 7; j++)
                {
                   double dist = FindDistance(stripArray[i], stripArray[j]);
                    if(dist < minStripDist)
                    {
                        minStripDist = dist;
                    }
                }
            }
            //update and return the minimum
            if(minStripDist < dHalfMin)
            {
                return minStripDist;
            }
            else
            {
                return dHalfMin;
            }

        }
		//calculate distance through simple euclidean distance formula
        public static double BruteForceCP(Point[] pointArray, int n)
        {
            double d_Distance = double.MaxValue;        //set the distance to an impossibly high value for the first comparison
            double dEuclideanDistance; 

            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    double x1 = pointArray[i].XCord;
                    double x2 = pointArray[j].XCord;
                    double y1 = pointArray[i].YCord;
                    double y2 = pointArray[j].YCord;
                    dEuclideanDistance = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2); 
                   dEuclideanDistance = Math.Sqrt(dEuclideanDistance); 
                    //dEuclideanDistance = Math.Sqrt(((pointArray[i].XCord - pointArray[j].XCord) * (pointArray[i].XCord - pointArray[j].XCord)) + ((pointArray[i].YCord - pointArray[j].YCord) * (pointArray[i].YCord - pointArray[j].YCord)));
                    if (dEuclideanDistance < d_Distance)
                        d_Distance = dEuclideanDistance;
                }//end for
            return d_Distance;
        }
        //euclidean distance formula
        public static double FindDistance(Point a, Point b)
        {
            double dEuclideanDistance;
            double x1 = a.XCord;
            double x2 = b.XCord;
            double y1 = a.YCord;
            double y2 = b.YCord;
            dEuclideanDistance = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            dEuclideanDistance = Math.Sqrt(dEuclideanDistance);
            //dEuclideanDistance = Math.Sqrt((a.XCord - b.XCord) * (a.XCord - b.XCord) + (a.YCord - b.YCord) * (a.YCord - b.YCord));
            return dEuclideanDistance;
        }

		//define a point as an x and y coordinate with integer values
        public class Point
        {
            public Point(int xCord, int yCord)
            {
                this.XCord = xCord;
                this.YCord = yCord;
            }

            public int XCord { get; set; }
            public int YCord { get; set; }
        }
        class PointCompareByX : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
            {
                if (p1.XCord > p2.XCord) return 1;
                else if (p1.XCord < p2.XCord) return -1;
                else return (p1.YCord > p2.YCord) ? 1 : (p1.YCord < p2.YCord) ? -1 : 0;
            }
        }

        class PointCompareByY : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
            {
                if (p1.YCord > p2.YCord) return 1;
                else if (p1.YCord < p2.YCord) return -1;
                else return (p1.XCord > p2.XCord) ? 1 : (p1.XCord < p2.XCord) ? -1 : 0;
            }
        }
    }
}


