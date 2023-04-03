//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct NumericLogixOps
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T identity<T>(T a)
            where T : unmanaged
                => gbits.identity(a);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @false<T>()
            where T:unmanaged
                => gbits.@false<T>();

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @false<T>(T a)
            where T:unmanaged
                => gbits.@false(a);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @false<T>(T a, T b)
            where T:unmanaged
                => gbits.@false(a,b);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @false<T>(T a, T b, T c)
            where T:unmanaged
                => gbits.@false(a,b,c);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @true<T>()
            where T:unmanaged
                => gbits.@true<T>();

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @true<T>(T a)
            where T:unmanaged
                => gbits.@true(a);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @true<T>(T a, T b)
            where T:unmanaged
                => gbits.@true(a, b);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T @true<T>(T a, T b, T c)
            where T:unmanaged
                => gbits.@true(a, b, c);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T not<T>(T a)
            where T : unmanaged
                => gbits.not(a);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xor1<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>((byte)(uint8(a) ^ byte.MaxValue));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(uint16(a)^ ushort.MaxValue);
            else if(typeof(T) == typeof(uint))
                return generic<T>(uint32(a)^ uint.MaxValue);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(uint64(a)^ ulong.MaxValue);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit testc<T>(T a)
            where T : unmanaged
                => gbits.pop(a) == width<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T and<T>(T a, T b)
            where T : unmanaged
                => gbits.and(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nand<T>(T a, T b)
            where T : unmanaged
                => gbits.nand(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T or<T>(T a, T b)
            where T : unmanaged
                => gbits.or(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nor<T>(T a, T b)
            where T : unmanaged
                => gbits.nor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xor<T>(T a, T b)
            where T : unmanaged
                => gbits.xor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xnor<T>(T a, T b)
            where T : unmanaged
                => gbits.xnor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T left<T>(T a, T b)
            where T : unmanaged
                => gbits.left(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T right<T>(T a, T b)
            where T : unmanaged
                => gbits.right(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T lnot<T>(T a, T b)
            where T : unmanaged
                => gbits.lnot(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T rnot<T>(T a, T b)
            where T : unmanaged
                => gbits.rnot(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T impl<T>(T a, T b)
            where T : unmanaged
                => gbits.impl(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T nonimpl<T>(T a, T b)
            where T : unmanaged
                => gbits.nonimpl(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cimpl<T>(T a, T b)
            where T : unmanaged
                => gbits.cimpl(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cnonimpl<T>(T a, T b)
            where T : unmanaged
                => gbits.cnonimpl(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xornot<T>(T a, T b)
            where T : unmanaged
                => gbits.xornot(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T add<T>(T a, T b)
            where T : unmanaged
                => gmath.add(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T sub<T>(T a, T b)
            where T : unmanaged
                => gmath.sub(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T div<T>(T a, T b)
            where T : unmanaged
                => gmath.div(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mod<T>(T a, T b)
            where T : unmanaged
                => gmath.mod(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T negate<T>(T a)
            where T : unmanaged
                => gmath.negate(a);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T inc<T>(T a)
            where T : unmanaged
                => gmath.inc(a);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T dec<T>(T a)
            where T : unmanaged
                => gmath.dec(a);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T equals<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.eq(a,b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T neq<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.neq(a,b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T lt<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.lt(a,b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T lteq<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.lteq(a,b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T gt<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.gt(a,b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T gteq<T>(T a, T b)
            where T : unmanaged
                => bits.promote<T>(gmath.gteq(a,b));

        [MethodImpl(Inline)]
        public static bit same<T>(T a, T b)
            where T : unmanaged
                => gmath.eq(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T sll<T>(T a, byte count)
            where T : unmanaged
                => gmath.sll(a, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T srl<T>(T a, byte count)
            where T : unmanaged
                => gmath.srl(a, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T rotl<T>(T a, byte count)
            where T : unmanaged
                => gbits.rotl(a, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T rotr<T>(T a, byte count)
            where T : unmanaged
                => gbits.rotr(a, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T select<T>(T a, T b, T c)
            where T : unmanaged
                => gbits.select(a,b,c);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f00<T>(T a, T b, T c)
            where T : unmanaged
                => default;

        // a nor (b or c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f01<T>(T a, T b, T c)
            where T : unmanaged
            => nor(a, or(b,c));

        // c and (b nor a)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f02<T>(T a, T b, T c)
            where T : unmanaged
                => and(c, nor(b,a));

         // b nor a
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f03<T>(T a, T b, T c)
            where T : unmanaged
                => nor(b,a);

        // b and (a nor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f04<T>(T a, T b, T c)
            where T : unmanaged
                => and(b, nor(a,c));

        // c nor a
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f05<T>(T a, T b, T c)
            where T : unmanaged
                => nor(c,a);

        // not a and (b xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f06<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(a), xor(b,c));

        // not a and (b xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f07<T>(T a, T b, T c)
            where T : unmanaged
                => nor(a, and(b,c));

        // (not a and b) and c
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f08<T>(T a, T b, T c)
            where T : unmanaged
                => and(and(not(a),b), c);

        // a nor (b xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f09<T>(T a, T b, T c)
            where T : unmanaged
                => nor(a, xor(b,c));

        // c and (not a)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0a<T>(T a, T b, T c)
            where T : unmanaged
                => and(c, not(a));

        // not a and ((b xor 1) or c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0b<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(a), or(xor1(b),  c));

        // b and (not a)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0c<T>(T a, T b, T c)
            where T : unmanaged
                => and(b, not(a));

        // not a and (b or (c xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0d<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(a), or(b, xor1(c)));

        // not a and (b or c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0e<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(a),or(b,c));

        // not a
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f0f<T>(T a, T b, T c)
            where T : unmanaged
                => not(a);

        // a and (b nor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f10<T>(T a, T b, T c)
            where T : unmanaged
                => and(a, nor(b, c));

        // c nor b
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f11<T>(T a, T b, T c)
            where T : unmanaged
                => nor(c,b);

        // not b and (a xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f12<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(b), xor(a,c));

        // b nor (a and c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f13<T>(T a, T b, T c)
            where T : unmanaged
                => nor(b, and(a,c));

        // not c and (a xor b)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f14<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(c), xor(a,b));

        // c nor (b and a)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f15<T>(T a, T b, T c)
            where T : unmanaged
                => nor(c, and(a,b));

        // a ? (b nor c) : (b xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f16<T>(T a, T b, T c)
            where T : unmanaged
                => select(a, nor(b,c), xor(b,c));

        // not(a ? (b or c) : (b and c))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f17<T>(T a, T b, T c)
            where T : unmanaged
                => not(select(a, or(b,c), and(b,c)));

        // (a xor b) and (a xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f18<T>(T a, T b, T c)
            where T : unmanaged
                => and(xor(a,b), xor(a,c));

        // not(((B xor C) xor (A and (B and C))))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f19<T>(T a, T b, T c)
            where T : unmanaged
                => not(xor(xor(b,c), and(a, and(b,c))));

        // not ((A and B)) and (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1a<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(a,b)), xor(a,c));

        // c ? not a : not b
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1b<T>(T a, T b, T c)
            where T : unmanaged
                => select(c, not(a), not(b));

        //not ((a and c)) and (a xor b)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1c<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(a,c)), xor(a,b));

        //b ? (not a) : (not c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1d<T>(T a, T b, T c)
            where T : unmanaged
                => select(b, not(a), not(c));

        //a xor (b or c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1e<T>(T a, T b, T c)
            where T : unmanaged
                => xor(a, or(b,c));

        // a nand (b or c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f1f<T>(T a, T b, T c)
            where T : unmanaged
                => nand(a, or(b,c));

        //((not b) and a) and C
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f20<T>(T a, T b, T c)
            where T : unmanaged
                => and(and(not(b),a),c);

        // b nor (a xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f21<T>(T a, T b, T c)
            where T : unmanaged
                => nor(b, xor(a,c));

        // c and (not b)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f22<T>(T a, T b, T c)
            where T : unmanaged
                => cnonimpl(c,b);

        // not (B) and ((A xor 1) or C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f23<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(b), or(not(a),c));

        // (a xor b) and (b xor c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f24<T>(T a, T b, T c)
            where T : unmanaged
                => and(xor(a,b), xor(b,c));

        // (not ((A and B)) and (A xor (C xor 1)))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f25<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(a,b)), xor(a, not(c)));

        // not ((A and B)) and (B xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f26<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(a,b)),xor(b,c));

        //C ? not (B) : not (A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f27<T>(T a, T b, T c)
            where T : unmanaged
                => select(c,not(b), not(a));

        //C and (B xor A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f28<T>(T a, T b, T c)
            where T : unmanaged
                => and(c,xor(b,a));

        // C ? (B xor A) : (B nor A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f29<T>(T a, T b, T c)
            where T : unmanaged
                => select(c, xor(b,a),nor(b,a));

        // C and (B nand A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2a<T>(T a, T b, T c)
            where T : unmanaged
                => and(c,nand(b,a));

        // C ? (B nand A) : (B nor A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2b<T>(T a, T b, T c)
            where T : unmanaged
                => select(c,nand(b,a), nor(b,a));

        // (B or C) and (A xor B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2c<T>(T a, T b, T c)
            where T : unmanaged
                => and(or(b,c), xor(a,b));

        // A xor (B or not (C))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2d<T>(T a, T b, T c)
            where T : unmanaged
                => xor(a, or(b, not(c)));

        // (B or C) xor (A and B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2e<T>(T a, T b, T c)
            where T : unmanaged
                => xor(or(b,c),and(a,b));

        // not (A) or (not (B) and C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f2f<T>(T a, T b, T c)
            where T : unmanaged
                => or(not(a),(and(not(b),c)));

        // a and not(b)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f30<T>(T a, T b, T c)
            where T : unmanaged
                => cnonimpl(a,b);

        // not (B) and (A or (C xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f31<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(b), or(a,not(c)));

        //not (B) and (A or C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f32<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(b),or(a,c));

        // not (B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f33<T>(T a, T b, T c)
            where T : unmanaged
                => not(b);

        // not ((B and C)) and (A xor B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f34<T>(T a, T b, T c)
            where T : unmanaged
            => and(not(and(b,c)), xor(a,b));

        // A ? not (B) : not (C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f35<T>(T a, T b, T c)
            where T : unmanaged
            => select(a,not(b),not(c));

        // B xor (A or C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f36<T>(T a, T b, T c)
            where T : unmanaged
            => xor(b,or(a,c));

        // B nand (A or C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f37<T>(T a, T b, T c)
            where T : unmanaged
            => nand(b,or(a,c));

        // (A or C) and (A xor B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f38<T>(T a, T b, T c)
            where T : unmanaged
            => and(or(a,c), xor(a,b));

        // B xor (A or (C xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f39<T>(T a, T b, T c)
            where T : unmanaged
                => xor(b, or(a, not(c)));

        // A ? not (B) : C
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3a<T>(T a, T b, T c)
            where T : unmanaged
            => select(a, not(b), c);

        // (not (A) and C) or (B xor 1)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3b<T>(T a, T b, T c)
            where T : unmanaged
            => or(and(not(a),c),xor1(b));

        // B xor A
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3c<T>(T a, T b, T c)
            where T : unmanaged
                => xor(b,a);

        // ((A xor B) or (A nor C))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3d<T>(T a, T b, T c)
            where T : unmanaged
            => or(xor(b,a),nor(a,c));

        // (not (A) and C) or (A xor B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3e<T>(T a, T b, T c)
            where T : unmanaged
                => or(and(not(a),c),xor(a,b));

        // B nand A
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f3f<T>(T a, T b, T c)
            where T : unmanaged
            => nand(b,a);

        // (not (C) and A) and B
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f40<T>(T a, T b, T c)
            where T : unmanaged
                => and(and(not(c),a),b);

        // C nor (B xor A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f41<T>(T a, T b, T c)
            where T : unmanaged
            => nor(c,xor(b,a));

        // (A xor C) and (B xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f42<T>(T a, T b, T c)
            where T : unmanaged
                => and(xor(a,c),xor(b,c));

        // not ((A and C)) and (A xor (B xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f43<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(a,c)), xor(a,xor1(b)));

        // B and not (C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f44<T>(T a, T b, T c)
            where T : unmanaged
                => cnonimpl(b,c);

        // not (C) and ((A xor 1) or B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f45<T>(T a, T b, T c)
            where T : unmanaged
            => and(not(c), or(xor1(a), b));

        // not ((A and C)) and (B xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f46<T>(T a, T b, T c)
            where T : unmanaged
            => and(not(and(a,c)),xor(b,c));

        // B ? not (C) : not (A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f47<T>(T a, T b, T c)
            where T : unmanaged
            => select(b,not(c),not(a));

        // B and (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f48<T>(T a, T b, T c)
            where T : unmanaged
            => and(b,xor(a,c));

        // B ? (A xor C) : (A nor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f49<T>(T a, T b, T c)
            where T : unmanaged
            => select(b,xor(a,c),nor(a,c));

        // (B or C) and (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4a<T>(T a, T b, T c)
            where T : unmanaged
                => and(or(b,c), xor(a,c));

         // A xor (not (B) or C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4b<T>(T a, T b, T c)
            where T : unmanaged
                => xor(a, or(not(b), c));

        // B and (A nand C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4c<T>(T a, T b, T c)
            where T : unmanaged
                => and(b, nand(a,c));

        // B ? (A nand C) : (A nor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4d<T>(T a, T b, T c)
            where T : unmanaged
                => select(b, nand(a,c),nor(a,c));

        // C ? not (A) : B
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4e<T>(T a, T b, T c)
            where T : unmanaged
                => select(c, not(a), b);

        // not (A) or (B and not (C))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f4f<T>(T a, T b, T c)
            where T : unmanaged
                => or(not(a),cnonimpl(b,c));

        // A and not (C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f50<T>(T a, T b, T c)
            where T : unmanaged
                => cnonimpl(a,c);

        // not (C) and (A or (B xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f51<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(c),or(a,xor1(b)));

        // not ((B and C)) and (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f52<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(and(b,c)),xor(a,c));

        // A ? not (C) : not (B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f53<T>(T a, T b, T c)
            where T : unmanaged
                => select(a, not(c), not(b));

        // not (C) and (A or B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f54<T>(T a, T b, T c)
            where T : unmanaged
                => and(not(c), or(a,b));

        // not (C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f55<T>(T a, T b, T c)
            where T : unmanaged
                => not(c);

        // C xor (B or A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f56<T>(T a, T b, T c)
            where T : unmanaged
                => xor(c,or(b,a));

        // C nand (B or A)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f57<T>(T a, T b, T c)
            where T : unmanaged
                => nand(c,or(b,a));

        // (A or B) and (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f58<T>(T a, T b, T c)
            where T : unmanaged
                => and(or(a,b),xor(a,c));

        // C xor (A or (B xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f59<T>(T a, T b, T c)
            where T : unmanaged
                => xor(c, or(a, not(b)));

        // C xor A
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5a<T>(T a, T b, T c)
            where T : unmanaged
                => xor(c,a);

        //((A xor C) or ((A or B) xor 1))
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5b<T>(T a, T b, T c)
            where T : unmanaged
                => or(xor(a,c), xor(or(a,b), Limits.maxval<T>()));

        //(A ? not (C) : B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5c<T>(T a, T b, T c)
            where T : unmanaged
                => select(a,not(c), b);

        // not (C) or (not (A) and B)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5d<T>(T a, T b, T c)
            where T : unmanaged
                => or(not(c), and(not(a), b));

        // (not (C) and B) or (A xor C)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5e<T>(T a, T b, T c)
            where T : unmanaged
                => or(and(not(c),b),(xor(a,c)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f5f<T>(T a, T b, T c)
            where T : unmanaged
                => nand(c,a);

        // a ? (b xnor c) : (b nand c)
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T f97<T>(T a, T b, T c)
            where T : unmanaged
                => select(c, xnor(b,c), nand(b,c));
    }
}