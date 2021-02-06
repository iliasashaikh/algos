using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos
{
    public static class Recursion
    {
        public static int Add(int[] a)
        {
            // S(n) = n + S(1:n)

            if (a.Length == 0)
                return 0;
            
            return a[a.Length-1] + Add(a.Skip(1).ToArray()) ;
        }

        public static void Reverse(int[] a)
        {
            int i = 0;
            void R(int index)
            {
                if (index == a?.Length - 1)
                {
                    a[index].Dump2();
                    return;
                }
                else
                    R(++i);

                a[index].Dump2();
            }

            R(0);
        }
    }
}
