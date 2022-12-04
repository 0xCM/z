//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// An extremely naive prime enumerator
    /// </summary>
    public struct PrimeEmitter
    {
        ulong Prior;

        [MethodImpl(Inline)]
        public static PrimeEmitter create(ulong prior = 1)
            => new PrimeEmitter(prior);

        [MethodImpl(Inline)]
        public PrimeEmitter(ulong prior)
        {
            Prior = prior;
        }

        [MethodImpl(Inline)]
        public ulong Next()
        {
            var next = Prior;
            while(!IsPrime(++next)){}
            Prior = next;
            return next;
        }

        [MethodImpl(Inline)]
        public bool IsPrime(ulong src)
        {
            var result = true;
            for(var i=2ul; i<src; i++)
            {
                if(src % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}