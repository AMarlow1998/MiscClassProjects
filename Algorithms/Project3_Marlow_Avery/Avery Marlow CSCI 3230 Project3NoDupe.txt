///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project: Project3: No Dupes
//	File Name: Project3NoDupe.cs
//	Description: Checks a sentence to see if there are any duplicate words; a way of proving if a sentence is unique.
//	Course: CSCI 3230 Algorithms
//	Author: Avery Marlow 
//	Created: 11-9-2020
//	Copyright: Avery Marlow, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3NoDupe
{
    class Project3NoDupe
    {
        /// <summary>Defines the entry point of the application.
        /// Take the user's input, break it into parts, and check if it's unique</summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {   
            //get the sentence from the user
            Console.WriteLine("Please enter a sentence");
            String strSent = Console.ReadLine().ToUpper();
            //use the string to construct our sentence object
            Sentence sent = new Sentence(strSent);
            //see if the sentence is unique
            bool uniqueSentence = sent.unique;
            //then return whether it is or it isn't.
            if(uniqueSentence == true)
            {
                Console.WriteLine("The Sentence is Unique");
            }
            else
            {
                Console.WriteLine("This Sentence is not Unique!");
            }
            Console.ReadLine();
        }
        /// <summary>Class that manages the creation of a sentence.
        /// It abstracts a sentence as an array of strings, then check each word against the others in the 
        /// array to see if it is unique.</summary>
        public class Sentence
        {
            public Boolean unique = true;  //initialize the sentence to unique by default
            public int numWords;       //store how many words are in the sentence
            private string[] sentence;      //abstract the string as an array of smaller sentences

            /// <summary>Initializes a new instance of the <see cref="Sentence"/> class.
            /// Stores the string in the sentence array and then evaluates the string array to see if each entry is unique.</summary>
            /// <param name="sent">The user passed sentence.</param>
            public Sentence(string sent)
            {
                sentence = sent.Split(' '); //break the user's sentence into words and store them
                numWords = sentence.Length; //store how many words the array has in it
                Evaluate();     //see if the sentence is unique
            }
            /// <summary>Evaluates each word in the sentence against every other word in the sentence.
            /// If any word matches as the same, change the unique property to false.</summary>
            public void Evaluate()
            {
                //use a nested for loop to compare each word against the others
                //[i] is the "subject" word
                //[j] is the word the subject is being compared against
                for(int i = 0;i<numWords;i++)
                {
                    for(int j = i+1; j<numWords;j++)
                    {
                        //see if the strings match
                        if (String.CompareOrdinal(sentence[i],sentence[j])==0)
                        {   
                            //if so, it violates the unique property so we can immediately return
                            unique = false;
                            return;
                        }
                    }
                }
            }

        }
            
    }
}
