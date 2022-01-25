using System;
using System.Collections.Generic;

namespace kattis
{
    class  RadioCommercials {
        static void Main(string[] args)
        {

            (int numberOfCommercials, int priceOfOneCommercial) firstInput = handleFirstInputLine();
            int[] arrayOfStudentsListeningPerBreak = handleSecondInputLine();
            int[] arrayOfNetIncomePerBreak = calculateNetIncomePerBreak(firstInput.priceOfOneCommercial, arrayOfStudentsListeningPerBreak);
            Console.WriteLine(maxSumSubSequence(arrayOfNetIncomePerBreak).ToString());
        }

        static int[] calculateNetIncomePerBreak(int priceOfOneCommercial, int[] arrayOfStudentsListeningPerBreak)
        {
            for(int i = 0; i < arrayOfStudentsListeningPerBreak.Length; i++)
            {
                int currentValue = arrayOfStudentsListeningPerBreak[i];
                arrayOfStudentsListeningPerBreak[i] = currentValue - priceOfOneCommercial;
            }

            return  arrayOfStudentsListeningPerBreak;
        }

        static int maxSumSubSequence(int[] array) 
        {            

            int maxSum = Int32.MinValue;
            int startIndexFinal = 0;
            int endIndexFinal = 0;
            int currentSum = 0;
            int startIndexCurrent = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];
                if(currentSum > maxSum) 
                {
                    maxSum = currentSum;
                    endIndexFinal = i;
                    startIndexFinal = startIndexCurrent;
                }
                if(currentSum <= 0)
                {
                    currentSum = 0;
                    startIndexCurrent = i + 1;
                }
            }            
            return maxSum;
        }


        static (int numberOfCommercials, int priceOfOneCommercial) handleFirstInputLine()
        {
            int numberOfCommercials = 0;
            int priceOfOneCommercial = 0;

            try {
                    var input = Console.ReadLine().Split(" ");

                    if(input != null)
                    {
                        Int32.TryParse(input[0], out numberOfCommercials);
                        Int32.TryParse(input[1], out priceOfOneCommercial);
                    }
                    else
                    {
                        Console.WriteLine("Input is missing. Stopping program.");
                        Environment.Exit(-1);   
                    }
            }
            catch(Exception err)
            {
                Console.WriteLine("Error parsing input. Stopping program.");
                Environment.Exit(-1);
            }

            return (numberOfCommercials, priceOfOneCommercial);
        }

        static int[] handleSecondInputLine()
        {
            try 
            {
                    var input = Console.ReadLine().Split(" ");
                    
                    int[] arrayOfStudentsListeningPerBreak = new int[input.Length];

                    if(input != null)
                    {
                        for (int i = 0; i < input.Length; i++) 
                        {
                            Int32.TryParse(input[i], out arrayOfStudentsListeningPerBreak[i]);
                        }                        
                    } 
                    else
                    {
                        Console.WriteLine("Input is missing. Stopping program.");
                        Environment.Exit(-1);   
                    }

                    return arrayOfStudentsListeningPerBreak;
            }
            catch(Exception err)
            {
                Console.WriteLine("Error parsing input. Stopping program.");
                Environment.Exit(-1);
            }

            return null;
        }
    }
}