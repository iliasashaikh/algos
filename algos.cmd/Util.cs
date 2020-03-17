using System;
using System.Collections;
using System.Collections.Generic;
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
            
        }

        private static void Dump2Jagged(Array a)
        {

        }
    }
}
