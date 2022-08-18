//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public static class NatPrime
    {
        /// <summary>
        /// Determines whether an integer is prime, very inefficiently
        /// </summary>
        /// <param name="x">The integer to examine</param>
        /// <typeparam name="T">The underlying integer type</typeparam>
        public static bool test(ulong x)
            => divisors(x).Count() == 0;

        static IEnumerable<ulong> range(ulong first, ulong last)
        {
            var current = first;
            if(first < last)
                while(current<= last)
                    yield return current++;
            else
                while(current >= last)
                    yield return current--;
        }

        static IEnumerable<ulong> divisors(ulong src)
        {
            if(src != 0 && src != 1)
            {
                var upper = src/2 + 1;
                var candidates = range(2ul, upper);
                foreach(var c in candidates)
                    if(src % c == 0 )
                        yield return c;
            }
        }
    }
}