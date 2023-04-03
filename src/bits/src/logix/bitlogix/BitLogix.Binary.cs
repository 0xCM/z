//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitLogix
    {
        [MethodImpl(Inline), Op]
        public static bit @false(bit a, bit b)
            => bit.Off;

        [MethodImpl(Inline), Op]
        public static bit @true(bit a, bit b)
            => bit.On;

        [MethodImpl(Inline), Op]
        public static bit and(bit a, bit b)
            => a & b;

        [MethodImpl(Inline), Op]
        public static bit nand(bit a, bit b)
            => !(a & b);

        [MethodImpl(Inline), Op]
        public static bit or(bit a, bit b)
            => a | b;

        [MethodImpl(Inline), Op]
        public static bit nor(bit a, bit b)
            => ~(a | b);

        [MethodImpl(Inline), Op]
        public static bit xor(bit a, bit b)
            => a ^ b;

        [MethodImpl(Inline), Op]
        public static bit xnor(bit a, bit b)
            => !(a ^ b);

        [MethodImpl(Inline), Op]
        public static bit impl(bit a, bit b)
            => a | ~b;

        [MethodImpl(Inline), Op]
        public static bit nonimpl(bit a, bit b)
            => ~a & b;

        [MethodImpl(Inline), Op]
        public static bit left(bit a, bit b)
            => a;

        [MethodImpl(Inline), Op]
        public static bit right(bit a, bit b)
            => b;

        [MethodImpl(Inline), Op]
        public static bit lnot(bit a, bit b)
            => !a;

        [MethodImpl(Inline), Op]
        public static bit rnot(bit a, bit b)
            => ~b;

        [MethodImpl(Inline), Op]
        public static bit cimpl(bit a, bit b)
            => ~a | b;

        [MethodImpl(Inline), Op]
        public static bit cnonimpl(bit a, bit b)
            => a & ~b;

        [MethodImpl(Inline)]
        public static bit same(bit a, bit b)
            => a == b;
    }
}