using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testarr = {1,1,2};
            Console.WriteLine(CountElements(testarr));
        }

        public static int CountElements(int[] arr) {
                int n = arr.Length;
                int count = 0;
                int[] plusOne = new int[n];
            //1.creating hashset and adding vals into it
                HashSet<int> h = new HashSet<int>();
                for(int i=0;i<n;i++){
                h.Add(arr[i]);
                }
            //2. checking x+1 value is present into hashset
                for(int i=0;i<n;i++){
                if(h.Contains(arr[i]+1))
                    count++;
                }
            return count;
            }

            
    }
}
