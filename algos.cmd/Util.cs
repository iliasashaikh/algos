using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algos
{
    public static class Util
    {
        public static void Dump2(this object o)
        {
            switch (o)
            {
                case Array a when a.GetValue(0) is Array:
                    Dump2Jagged(a);
                    break;
                case Array a when a.Rank == 1:
                    ConsoleDump.Extensions.DumpObject(a);
                    break;
                case Array a when a.Rank == 2:
                    Dump2Array2(a);
                    break;
                case IEnumerable e:
                    ConsoleDump.Extensions.DumpObject(e);
                    break;
            }
        }

        private static void Dump2Array2(Array a)
        {
            Console.Write(string.Join(',', Enumerable.Cast<object>(a).ToArray())); 
        }

        private static void Dump2Jagged(Array a)
        {
            var ja = a as object[][];
            for (int i = 0; i < a.Length; i++)
            {
                var ji = a.GetValue(i) as Array;
                Dump2Array2(ji);
                Console.WriteLine();
            }
        }
    }
}
