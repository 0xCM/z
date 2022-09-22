//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Reads a pair of sequences in tandem, termininating when either source is depleted
    /// </summary>
    public unsafe struct SeqReader<A0,A1>
        where A0 : unmanaged
        where A1 : unmanaged
    {
        SeqReader<A0> R0;

        SeqReader<A1> R1;

        [MethodImpl(Inline)]
        internal SeqReader(SeqReader<A0> r0, SeqReader<A1> r1)
        {
            R0 = r0;
            R1 = r1;
        }

        [MethodImpl(Inline)]
        public bool Next(out A0 a, out A1 b)
        {
            var result = R0.Next(out a);
            result &= R1.Next(out b);
            return result;
        }
    }
}