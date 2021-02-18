using NUnit.Framework;
using NUnitLite;
using System;
using System.Reflection;

public class Runner
{
    public static int Main(string[] args)
    {
        return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] { "--labels=All" });


        static void Main(string[] args)
        {
            //Console.WriteLine(Search.Search.BinarySearch(new int[] { 1, 2, 3, 4 }, 10));
            //Console.WriteLine(Search.Search.BinarySearch(new int[] { 1, 2, 3, 4 }, 0));
            //Console.WriteLine(Search.Search.BinarySearch(new int[] { 1, 2, 3, 4 }, 1));
            //Console.WriteLine(Search.Search.BinarySearch(new int[] { 1, 2, 3, 4 }, 2));
            //Console.WriteLine(Search.Search.BinarySearch(new int[] { 1, 2, 3, 4 }, 4));

            //Zombie.Test();
            //Recursion.Reverse(new int[] {1,2,3});
            //SumPairs.Run();
            //MoveZeros.Run();
            //Console.WriteLine($"Sum : {Recursion.Add(new int[] { 1, 2, 3 })}");
            //LongestSubstring.Run();
            MininumWindowSubstring.Run();
        }



    }

    
    
}
