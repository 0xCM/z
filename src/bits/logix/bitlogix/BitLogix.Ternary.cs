//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitLogix
    {
        [MethodImpl(Inline), Op]
        public static bit select(bit a, bit b, bit c)
            => bit.select(a,b,c);

        [MethodImpl(Inline), Op]
        public static bit @false(bit a, bit b, bit c)
            => bit.Off;

        [MethodImpl(Inline), Op]
        public static bit @true(bit a, bit b, bit c)
            => bit.On;

        // a nor (b or c)
        [MethodImpl(Inline), Op]
        public static bit f01(bit a, bit b, bit c)
            => nor(a, or(b,c));

        // c and (b nor a)
        [MethodImpl(Inline), Op]
        public static bit f02(bit a, bit b, bit c)
            => and(c, nor(b,a));

        // b nor a
        [MethodImpl(Inline), Op]
        public static bit f03(bit a, bit b, bit c)
            => nor(b,a);

        // b and (a nor c)
        [MethodImpl(Inline), Op]
        public static bit f04(bit a, bit b, bit c)
            => and(b, nor(a,c));

        // c nor a
        [MethodImpl(Inline), Op]
        public static bit f05(bit a, bit b, bit c)
            => nor(c,a);

        // not a and (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f06(bit a, bit b, bit c)
            => and(not(a), xor(b,c));

        // not a and (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f07(bit a, bit b, bit c)
            => nor(a, and(b,c));

        // (not a and b) and c
        [MethodImpl(Inline), Op]
        public static bit f08(bit a, bit b, bit c)
            => and(and(not(a),b), c);

        // a nor (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f09(bit a, bit b, bit c)
            => nor(a, xor(b,c));

        // c and (not a)
        [MethodImpl(Inline), Op]
        public static bit f0a(bit a, bit b, bit c)
            => and(c, not(a));

        // not a and ((b xor 1) or c)
        [MethodImpl(Inline), Op]
        public static bit f0b(bit a, bit b, bit c)
            => and(not(a), or(not(b),  c));

        // b and (not a)
        [MethodImpl(Inline), Op]
        public static bit f0c(bit a, bit b, bit c)
            => and(b, not(a));

        // not (A) and (B or (C xor 1))
        [MethodImpl(Inline), Op]
        public static bit f0d(bit a, bit b, bit c)
            => and(not(a), or(b, not(c)));

        // not a and (b or c)
        [MethodImpl(Inline), Op]
        public static bit f0e(bit a, bit b, bit c)
            => and(not(a),or(b,c));

        // not a
        [MethodImpl(Inline), Op]
        public static bit f0f(bit a, bit b, bit c)
            => not(a);

        // a and (b nor c)
        [MethodImpl(Inline), Op]
        public static bit f10(bit a, bit b, bit c)
            => and(a, nor(b, c));

        // c nor b
        [MethodImpl(Inline), Op]
        public static bit f11(bit a, bit b, bit c)
            => nor(c,b);

        // not b and (a xor c)
        [MethodImpl(Inline), Op]
        public static bit f12(bit a, bit b, bit c)
            => and(not(b), xor(a,c));

        // b nor (a and c)
        [MethodImpl(Inline), Op]
        public static bit f13(bit a, bit b, bit c)
            => nor(b, and(a,c));

        // not c and (a xor b)
        [MethodImpl(Inline), Op]
        public static bit f14(bit a, bit b, bit c)
            => and(not(c), xor(a,b));

        // c nor (b and a)
        [MethodImpl(Inline), Op]
        public static bit f15(bit a, bit b, bit c)
            => nor(c, and(a,b));

        // a ? (b nor c) : (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f16(bit a, bit b, bit c)
            => select(a, nor(b,c), xor(b,c));

        // not(a ? (b or c) : (b and c))
        [MethodImpl(Inline), Op]
        public static bit f17(bit a, bit b, bit c)
            => not(select(a, or(b,c), and(b,c)));

        // (a xor b) and (a xor c)
        [MethodImpl(Inline), Op]
        public static bit f18(bit a, bit b, bit c)
            => and(xor(a,b), xor(a,c));

        // not(((B xor C) xor (A and (B and C))))
        [MethodImpl(Inline), Op]
        public static bit f19(bit a, bit b, bit c)
            => not(xor(xor(b,c), and(a, and(b,c))));

        // not ((a and b)) and (a xor c)
        [MethodImpl(Inline), Op]
        public static bit f1a(bit a, bit b, bit c)
            => and(not(and(a,b)), xor(a,c));

        // c ? not a : not b
        [MethodImpl(Inline), Op]
        public static bit f1b(bit a, bit b, bit c)
            => select(c, not(a), not(b));

        //not ((a and c)) and (a xor b)
        [MethodImpl(Inline), Op]
        public static bit f1c(bit a, bit b, bit c)
            => and(not(and(a,c)), xor(a,b));

        //b ? (not a) : (not c)
        [MethodImpl(Inline), Op]
        public static bit f1d(bit a, bit b, bit c)
            => select(b, not(a), not(c));

        //a xor (b or c)
        [MethodImpl(Inline), Op]
        public static bit f1e(bit a, bit b, bit c)
            => xor(a, or(b,c));

        // a nand (b or c)
        [MethodImpl(Inline), Op]
        public static bit f1f(bit a, bit b, bit c)
            => nand(a, or(b,c));

        //((not b) and a) and C
        [MethodImpl(Inline), Op]
        public static bit f20(bit a, bit b, bit c)
            => and(cnonimpl(a,b),c);

        // b nor (a xor c)
        [MethodImpl(Inline), Op]
        public static bit f21(bit a, bit b, bit c)
            => nor(b, xor(a,c));

        // c and (not b)
        [MethodImpl(Inline), Op]
        public static bit f22(bit a, bit b, bit c)
            => cnonimpl(c,b);

        // not (B) and ((A xor 1) or C)
        [MethodImpl(Inline), Op]
        public static bit f23(bit a, bit b, bit c)
            => and(not(b),or(not(a),c));

        // (a xor b) and (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f24(bit a, bit b, bit c)
            => and(xor(a,b), xor(b,c));

        // (not ((a and b)) and (a xor (c xor 1)))
        [MethodImpl(Inline), Op]
        public static bit f25(bit a, bit b, bit c)
            => and(not(and(a,b)), xor(a, not(c)));

        //not ((a and b)) and (b xor c)
        [MethodImpl(Inline), Op]
        public static bit f26(bit a, bit b, bit c)
            => and(not(and(a,b)), xor(b,c));

        // C ? not (B) : not (A)
        [MethodImpl(Inline), Op]
        public static bit f27(bit a, bit b, bit c)
            => select(c, not(b), not(a));

        // C and (B xor A)
        [MethodImpl(Inline), Op]
        public static bit f28(bit a, bit b, bit c)
            => and(c, xor(b,a));

        // C ? (B xor A) : (B nor A)
        [MethodImpl(Inline), Op]
        public static bit f29(bit a, bit b, bit c)
            => select(c, xor(b,a), nor(b,a));

        // C and (B nand A)
        [MethodImpl(Inline), Op]
        public static bit f2a(bit a, bit b, bit c)
            => and(c, nand(b,a));

        // C ? (B nand A) : (B nor A)
        [MethodImpl(Inline), Op]
        public static bit f2b(bit a, bit b, bit c)
            => select(c, nand(b,a), nor(b,a));

        // (B or C) and (A xor B)
        [MethodImpl(Inline), Op]
        public static bit f2c(bit a, bit b, bit c)
            => and(or(b,c), xor(a,b));

        // A xor (B or not (C))
        [MethodImpl(Inline), Op]
        public static bit f2d(bit a, bit b, bit c)
            => xor(a,(or(b,not(c))));

        // (B or C) xor (A and B)
        [MethodImpl(Inline), Op]
        public static bit f2e(bit a, bit b, bit c)
            => xor(or(b,c), and(a,b));

        // not (A) or (not (B) and C)
        [MethodImpl(Inline), Op]
        public static bit f2f(bit a, bit b, bit c)
            => or(not(a), and(not(b),c));

        // a and not(b)
        [MethodImpl(Inline), Op]
        public static bit f30(bit a, bit b, bit c)
            => cnonimpl(a,b);

        // not (B) and (A or (C xor 1))
        [MethodImpl(Inline), Op]
        public static bit f31(bit a, bit b, bit c)
            => and(not(b), or(a,not(c)));

        //not (B) and (A or C)
        [MethodImpl(Inline), Op]
        public static bit f32(bit a, bit b, bit c)
            => and(not(b),or(a,c));

        // not (B)
        [MethodImpl(Inline), Op]
        public static bit f33(bit a, bit b, bit c)
            => not(b);

        // not ((B and C)) and (A xor B)
        [MethodImpl(Inline), Op]
        public static bit f34(bit a, bit b, bit c)
            => and(not(and(b,c)), xor(a,b));

        // A ? not (B) : not (C)
        [MethodImpl(Inline), Op]
        public static bit f35(bit a, bit b, bit c)
            => select(a,not(b),not(c));

        // B xor (A or C)
        [MethodImpl(Inline), Op]
        public static bit f36(bit a, bit b, bit c)
            => xor(b,or(a,c));

        // B nand (A or C)
        [MethodImpl(Inline), Op]
        public static bit f37(bit a, bit b, bit c)
            => nand(b,or(a,c));

        // (A or C) and (A xor B)
        [MethodImpl(Inline), Op]
        public static bit f38(bit a, bit b, bit c)
            => and(or(a,c), xor(a,b));

        // B xor (A or (C xor 1))
        [MethodImpl(Inline), Op]
        public static bit f39(bit a, bit b, bit c)
            => xor(b, or(a, not(c)));

        // A ? not (B) : C
        [MethodImpl(Inline), Op]
        public static bit f3a(bit a, bit b, bit c)
            => select(a, not(b), c);

        // (not (A) and C) or (B xor 1)
        [MethodImpl(Inline), Op]
        public static bit f3b(bit a, bit b, bit c)
            => or(and(not(a),c),not(b));

        // B xor A
        [MethodImpl(Inline), Op]
        public static bit f3c(bit a, bit b, bit c)
            => xor(b,a);

        // ((A xor B) or (A nor C))
        [MethodImpl(Inline), Op]
        public static bit f3d(bit a, bit b, bit c)
            => or(xor(b,a),nor(a,c));

        // (not (A) and C) or (A xor B)
        [MethodImpl(Inline), Op]
        public static bit f3e(bit a, bit b, bit c)
            => or(and(not(a),c),xor(a,b));

        // B nand A
        [MethodImpl(Inline), Op]
        public static bit f3f(bit a, bit b, bit c)
            => nand(b,a);

        // (not (C) and A) and B
        [MethodImpl(Inline), Op]
        public static bit f40(bit a, bit b, bit c)
            => and(and(not(c),a),b);

        // C nor (B xor A)
        [MethodImpl(Inline), Op]
        public static bit f41(bit a, bit b, bit c)
            => nor(c,xor(b,a));

        // (A xor C) and (B xor C)
        [MethodImpl(Inline), Op]
        public static bit f42(bit a, bit b, bit c)
            => and(xor(a,c),xor(b,c));

        // not ((A and C)) and (A xor (B xor 1))
        [MethodImpl(Inline), Op]
        public static bit f43(bit a, bit b, bit c)
            => and(not(and(a,c)), xor(a,not(b)));

        // B and not (C)
        [MethodImpl(Inline), Op]
        public static bit f44(bit a, bit b, bit c)
            => cnonimpl(b,c);

        // not (C) and ((A xor 1) or B)
        [MethodImpl(Inline), Op]
        public static bit f45(bit a, bit b, bit c)
            => and(not(c), or(not(a), b));

        // not ((A and C)) and (B xor C)
        [MethodImpl(Inline), Op]
        public static bit f46(bit a, bit b, bit c)
            => and(not(and(a,c)),xor(b,c));

        // B ? not (C) : not (A)
        [MethodImpl(Inline), Op]
        public static bit f47(bit a, bit b, bit c)
            => select(b,not(c),not(a));

        // B and (A xor C)
        [MethodImpl(Inline), Op]
        public static bit f48(bit a, bit b, bit c)
            => and(b,xor(a,c));

        // B ? (A xor C) : (A nor C)
        [MethodImpl(Inline), Op]
        public static bit f49(bit a, bit b, bit c)
            => select(b,xor(a,c),nor(a,c));

        // (B or C) and (A xor C)
        [MethodImpl(Inline), Op]
        public static bit f4a(bit a, bit b, bit c)
            => and(or(b,c), xor(a,c));

         // A xor (not (B) or C)
        [MethodImpl(Inline), Op]
        public static bit f4b(bit a, bit b, bit c)
            => xor(a, or(not(b), c));

        // B and (A nand C)
        [MethodImpl(Inline), Op]
        public static bit f4c(bit a, bit b, bit c)
            => and(b, nand(a,c));

        // B ? (A nand C) : (A nor C)
        [MethodImpl(Inline), Op]
        public static bit f4d(bit a, bit b, bit c)
            => select(b, nand(a,c),nor(a,c));

        // C ? not (A) : B
        [MethodImpl(Inline), Op]
        public static bit f4e(bit a, bit b, bit c)
            => select(c, not(a), b);

        // not (A) or (B and not (C))
        [MethodImpl(Inline), Op]
        public static bit f4f(bit a, bit b, bit c)
            => or(not(a),cnonimpl(b,c));

        // A and not (C)
        [MethodImpl(Inline), Op]
        public static bit f50(bit a, bit b, bit c)
            => cnonimpl(a,c);

        // not (C) and (A or (B xor 1))
        [MethodImpl(Inline), Op]
        public static bit f51(bit a, bit b, bit c)
            => and(not(c),or(a,not(b)));

        // not ((B and C)) and (A xor C)
        [MethodImpl(Inline), Op]
        public static bit f52(bit a, bit b, bit c)
            => and(not(and(b,c)),xor(a,c));

        // A ? not (C) : not (B)
        [MethodImpl(Inline), Op]
        public static bit f53(bit a, bit b, bit c)
            => select(a, not(c), not(b));

        // not (C) and (A or B)
        [MethodImpl(Inline), Op]
        public static bit f54(bit a, bit b, bit c)
            => and(not(c), or(a,b));

        // not (C)
        [MethodImpl(Inline), Op]
        public static bit f55(bit a, bit b, bit c)
            => not(c);

        // C xor (B or A)
        [MethodImpl(Inline), Op]
        public static bit f56(bit a, bit b, bit c)
            => xor(c,or(b,a));

        // C nand (B or A)
        [MethodImpl(Inline), Op]
        public static bit f57(bit a, bit b, bit c)
            => nand(c,or(b,a));

        // (A or B) and (A xor C)
        [MethodImpl(Inline), Op]
        public static bit f58(bit a, bit b, bit c)
            => and(or(a,b),xor(a,c));

        // C xor (A or (B xor 1))
        [MethodImpl(Inline), Op]
        public static bit f59(bit a, bit b, bit c)
            => xor(c, or(a, not(b)));

        // C xor A
        [MethodImpl(Inline), Op]
        public static bit f5a(bit a, bit b, bit c)
            => xor(c,a);

        //((A xor C) or ((A or B) xor 1))
        [MethodImpl(Inline), Op]
        public static bit f5b(bit a, bit b, bit c)
            => or(xor(a,c), xor(or(a,b),bit.On));

        //(A ? not (C) : B)
        [MethodImpl(Inline), Op]
        public static bit f5c(bit a, bit b, bit c)
            => select(a,not(c), b);

        // not (C) or (not (A) and B)
        [MethodImpl(Inline), Op]
        public static bit f5d(bit a, bit b, bit c)
            => or(not(c), and(not(a), b));

        // (not (C) and B) or (A xor C)
        [MethodImpl(Inline), Op]
        public static bit f5e(bit a, bit b, bit c)
            => or(and(not(c),b),(xor(a,c)));

        [MethodImpl(Inline), Op]
        public static bit f5f(bit a, bit b, bit c)
            => nand(c,a);

        [MethodImpl(Inline)]
        public static bit f60(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f61(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f62(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f63(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f64(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f65(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f66(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f67(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f68(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f69(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6a(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6b(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6c(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6d(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6e(bit a, bit b, bit c)
            => default;

        [MethodImpl(Inline)]
        public static bit f6f(bit a, bit b, bit c)
            => default;
    }
}