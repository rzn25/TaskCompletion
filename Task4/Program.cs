using System;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] array = {"5","2","C","D","+"};
            int n = array.Length;            
            
            int[] arr = new int[n];
            int index = 0;

            for(int i=0; i<n; i++)
            {
                switch(array[i])
                {
                    case "+":
                        arr[index] = Convert.ToInt32(arr[index - 1]) + Convert.ToInt32(arr[index - 2]);
                        index += 1;
                        break;

                    case "C":
                        arr = arr.Where((source, i) => i != index - 1).ToArray();
                        index -= 1;
                        break;
                    case "D":
                        arr[index] = Convert.ToInt32(arr[index - 1]) * 2;
                        index += 1;
                        break;
                    default:
                        arr[index] = int.Parse(array[i]);
                        index += 1;
                        break;
                }
            }

            int totalScore = arr.Sum();

            Console.WriteLine("Total Score is :- "+ totalScore);
        }
    }
}
