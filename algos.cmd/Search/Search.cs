using System;
using System.Collections.Generic;
using System.Text;

namespace algos
{
    public static class Search
    {
        public static int BinarySearch(int[] sortedArray, int target)
        {
            return BinarySearch(sortedArray, 0, sortedArray.Length-1, target);
        }

        static int BinarySearch(int[] sortedArray, int left, int right, int target)
        {
            if (right >= left)
            {
                var mid = (left + right) / 2;
                var midValue = sortedArray[(left + right) / 2];

                if (midValue == target)
                    return mid;

                if (target > midValue)
                {
                    return BinarySearch(sortedArray, mid + 1, right, target);
                }

                return BinarySearch(sortedArray, left, mid - 1, target);
            }

            return -1;
        }

        public static int BinarySearchRotated(int[] sortedRotatedArray, int target)
        {
            int pivot = FindPivot(sortedRotatedArray);
            
            if (target == sortedRotatedArray[pivot])
                return pivot;

            if (target > sortedRotatedArray[pivot])
            {
                int[] t = new int[sortedRotatedArray.Length - pivot - 1];
                Array.Copy(sortedRotatedArray, pivot + 1, t, 0, sortedRotatedArray.Length - pivot - 1);
                var r = BinarySearch(t,target);
                return r == -1 ? -1 : pivot + r;
            }

            
            int[] t2 = new int[pivot];
            Array.Copy(sortedRotatedArray, 0, t2, 0, pivot);
            var r2 = BinarySearch(t2, target);
            return r2;
        }

        private static int FindPivot(int[] sortedRotatedArray)
        {
            //0 1 2 3 => 2 3 0 1
            var mid = sortedRotatedArray.Length / 2;
            var midVal = sortedRotatedArray[mid];
            
            if (mid + 1 >= sortedRotatedArray.Length)
                return -1;

            var midNextVal = sortedRotatedArray[mid + 1];
            if (midNextVal < midVal)
            {
                return mid;
            }

            if (mid-1>0)
            {
                
            }

            throw new NotImplementedException();
        }
    }
}
