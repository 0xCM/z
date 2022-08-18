//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct EvalSeq
    {
        public static SeqEval<T> alloc<T>(uint count, bit result)
            => new SeqEval<T>(new BinaryEval<T>[count], result);

        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static ref SeqEval<T> eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ref SeqEval<T> dst)
            where T : unmanaged, IEquatable<T>
        {
            var count = a.Length;
            if(count != b.Length || count == 0)
                return ref dst;

            var success = bit.On;
            for(var i=0u; i<count; i++)
            {
                ref readonly var x = ref skip(a,i);
                ref readonly var y = ref skip(b,i);
                dst[i] = eq(x,y, out var judgement);
                success &= judgement.Result;
            }
            dst.Result = success;
            return ref dst;
        }

        [Op, Closures(UInt64k)]
        public static SeqEval<T> eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged, IEquatable<T>
        {
            var dst = alloc<T>((uint)a.Length, true);
            return eq(a,b, ref dst);
        }


        [Op, Closures(Closure)]
        public static ref BinaryEval<T> eq<T>(T a, T b, out BinaryEval<T> dst)
            where T : IEquatable<T>
        {
            dst = new BinaryEval<T>(a, b, a.Equals(b));
            return ref dst;
        }
    }
}