//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitSpans32
    {
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 and(in BitSpan32 x, in BitSpan32 y, in BitSpan32 z)
        {
            var bitcount = z.Length;
            for(var i=0; i< bitcount; i++)
                z[i] = x[i] & y[i];
            return ref z;
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 and(in BitSpan32 x, in BitSpan32 y)
            => and(x,y, alloc(y.Length));

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 or(in BitSpan32 x, in BitSpan32 y, in BitSpan32 z)
        {
            var bitcount = z.Length;
            for(var i=0; i< bitcount; i++)
                z[i] = x[i] | y[i];
            return ref z;
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 or(in BitSpan32 x, in BitSpan32 y)
            => or(x, y, alloc(y.Length));

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 xor(in BitSpan32 x, in BitSpan32 y, in BitSpan32 z)
        {
            var bitcount = z.Length;
            for(var i=0; i< bitcount; i++)
                z[i] = x[i] ^ y[i];
            return ref z;
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 xor(in BitSpan32 x, in BitSpan32 y)
            => xor(x,y, alloc(y.Length));

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 not(in BitSpan32 x, in BitSpan32 z)
        {
            var bitcount = z.Length;
            for(var i=0; i<bitcount; i++)
                z[i] = ~ x[i];
            return ref z;
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 not(in BitSpan32 x)
            => not(x,alloc(x.Length));

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 select(in BitSpan32 a, in BitSpan32 b, in BitSpan32 c, in BitSpan32 z)
        {
            var tmp = alloc(z.Length);
            not(a,tmp);
            and(a,b,z);
            and(tmp,c, tmp);
            or(z,tmp,z);
            return ref z;
        }

        /// <summary>
        /// Computes the ternary select s := a ? b : c = (a & b) | (~a & c)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 select(in BitSpan32 a, in BitSpan32 b, in BitSpan32 c)
            => select(a,b,c, alloc(c.Length));

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 sll(in BitSpan32 a, int offset, in BitSpan32 z)
        {
            a.Data.Slice(0, offset).CopyTo(z.Data, offset);
            for(var i=0; i<offset; i++)
                z[i] = Bit32.Off;
            return ref z;
        }

        [MethodImpl(Inline), Op]
        public static Bit32 same(in BitSpan32 a, in BitSpan32 b)
        {
            if(a.Length != b.Length)
                return false;

            for(var i=0; i<a.Length; i++)
                if(a[i] != b[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Computes the number of enabled bits covered by source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static int pop(in BitSpan32 src)
        {
            var enabled = 0;
            var bitcount = src.Length;
            for(var i=0; i< bitcount; i++)
                enabled += (int)src[i];
            return enabled;
        }
    }
}