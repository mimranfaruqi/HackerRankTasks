using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    /// <summary>
    /// Hour Glass problem
    /// </summary>
    public class HourGlass
    {
        /// <summary>
        /// Result of Hour Glass problem - highest value among the sum of all glasses in a 6x6 matrix.
        /// The problem is defined at <see href="https://www.hackerrank.com/challenges/2d-array/problem?isFullScreen=true&amp;h_l=interview&amp;playlist_slugs%5B%5D=interview-preparation-kit&amp;playlist_slugs%5B%5D=arrays"/>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int HourglassSum(List<List<int>> arr)
        {
            var moveIndex = 1;
            var sums = new int[16];

            var counter = 0;
            
            for (var i = 0; i < arr.Count; i++)
            {
                if (i + 2 > 5) break;
                
                for (var j = 0; j < arr[i].Count; j++)
                {
                    if (j + 2 > 5) break;
                
                    sums[counter++] = 
                        arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + // glass top
                        arr[i + 1][j + 1] + // glass middle
                        arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]; // glass bottom
                }
            }
            counter = 0;
            foreach (var sum in sums)
            {
                if (counter == 4)
                {
                    counter = 0;
                    Console.WriteLine();
                }
                counter++;
                Console.Write(sum);
                Console.Write("\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            return sums.Max();
        }

        private static List<List<int>> GenerateProblem()
        {
            var list = new List<List<int>>();

            for (var i = 0; i < 6; i++)
            {
                var temp = new List<int>();
                for (var j = 0; j < 6; j++)
                {
                    temp.Add(new Random().Next(100));
                }
                list.Add(temp);
            }
            
            foreach (var row in list)
            {
                foreach (var item in row)
                {
                    Console.Write(item);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            return list;
        }

        public static void Run()
        {
            Console.WriteLine("Result of Hour Glass problem: " + HourglassSum(GenerateProblem()));
        }
    }
}