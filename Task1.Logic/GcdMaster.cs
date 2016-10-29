using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public static class GcdMaster
    {
        public static long? Gcd(long x, long y)
        {
            if (x == 0 && y == 0)
                return null;
            return ComputeGcd(x, y);
        }

        private static long ComputeGcd(long x, long y)
        {
            if (x == 0)
                return y;
            while (x != 0 && y != 0)
            {
                if (x < y)
                {
                    y %= x;
                }
                else
                {
                    x %= y;
                }
            }
            if (x == 0)
                return y;
            return x;
        }
    }
}
