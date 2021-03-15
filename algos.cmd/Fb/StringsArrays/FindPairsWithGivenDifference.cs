using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.StringsArrays
{
    using System;
    using System.Collections.Generic;

    /*
           function findPairsWithGivenDifference(arr, k):
    # since we don't allow duplicates, no pair can satisfy x - 0 = y
    if k == 0:
        return []
        
    map = {}
    answer = []
    
    for (x in arr):
        map[x - k] = x
    
    for (y in arr):
        if y in map:
            answer.push([map[y], y]) 

    return answer
     
     */

    /*
     
    using System;

class Solution
{
    public static double Root(double x, int n)
    {
      double left = 0.0, right = x;

      while(left < right){
        var mid = left + (right - left) / 2;
        double temp = 1.0;
        for(int i = 0; i < n; i++){
          temp *= mid;
        }
        if(temp < x){
          left = mid + 0.001;
        }
        else{
          right = mid;
        }
      }
      
      return right;
    }

    static void Main(string[] args)
    {

    }
}
     
     */

    class Solution
    {
        public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
        {
            // your code goes here


            // output: [[1, 0], [0, -1], [-1, -2], [2, 1]]

            // a+b = k 
            // a = b + k



            HashSet<int> set = new HashSet<int>();
            List<int[]> result = new List<int[]>();


            for (int i = 0; i < arr.Length; i++)
            {
                set.Add(arr[i]);
            }

            //set:[0, -1, -2, 2, 1]
            //result:[0,-1],[-1,-2],[2,1],[1,0]

            //result:[1,0],[0,-1],[-1,-2],[2,1]
            for (int i = 0; i < arr.Length; i++)
            {
                var offset = arr[i] + k;

                if (set.Contains(offset) && offset != arr[i])
                    result.Add(new int[2] { offset, arr[i] });
            }

            int[,] resultArray = new int[result.Count, 2];
            for (int i = 0; i < result.Count; i++)
            {
                resultArray[i, 0] = result[i][0];
                resultArray[i, 1] = result[i][1];
            }

            return resultArray;
        }

        
    }


}
