//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct CallPatterns
    {
        public delegate byte Mul(byte x, byte y);

        public static byte mul(byte x, byte y)
            => (byte)(x*y);

        [Op]
        public static FPtr<Mul> testFptr()
        {
            Mul f = mul;
            return memory.fptr(f);
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static void binop<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right, Func<T,T,T> f, Span<T> results)
        {
            var count = left.Length;
            ref readonly var a = ref first(left);
            ref readonly var b = ref first(right);
            ref var c = ref first(results);
            for(var i=0u; i<count; i++)
                seek(c,i) = f(skip(a,i), skip(b,i));
        }

        public static void binop<T>(uint count, in T left, in T right, Func<T,T,T> f, ref T dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(left,i), skip(right,i));
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void binop<T>(uint count, in Pair<T> src, Func<T,T,T> f, ref T dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }

        [Op]
        public static void binop(uint count, in Pair<uint> src, Func<uint,uint,uint> f, ref uint dst)
            => binop<uint>(count, src, f, ref dst);

        [Op]
        public static void binfunc(uint count, in Paired<uint,byte> src, Func<uint,byte,ulong> f, ref ulong dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }

        [MethodImpl(Inline)]
        public static void binfunc<A,B,C>(uint count, in Paired<A,B> src, Func<A,B,C> f, ref C dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = f(skip(src,i).Left, skip(src,i).Right);
        }
    }
}