//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;
    using static LogicSig;
    using static gcpu;

    using ULK = UnaryBitLogicKind;
    using BLK = BinaryBitLogicKind;
    using TLK = TernaryBitLogicKind;
    using BSK = BitShiftClass;
    using BCK = ApiComparisonClass;
    using BAR = ApiBinaryArithmeticClass;

    [ApiHost]
    public static partial class VLogix
    {
        /// <summary>
        /// Advertises the supported unary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<ULK> UnaryBitLogicKinds
            => Enums.literals<ULK>();

        /// <summary>
        /// Advertises the supported binary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<BLK> BinaryBitLogicKinds
            => Enums.literals<BLK>();

        /// <summary>
        /// Advertises the supported ternary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<TLK> TernaryBitLogicKinds
            => gcalc.stream((byte)1,(byte)TLK.X18).Cast<TLK>().ToArray();

        /// <summary>
        /// Specifies the supported comparison operators
        /// </summary>
        public static ReadOnlySpan<BCK> ComparisonKinds
            => array(BCK.Eq, BCK.Lt, BCK.Gt);

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        public static UnaryOp<Vector128<T>> lookup<T>(N128 w, ULK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return vnot;
                case ULK.Identity: return videntity;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        public static UnaryOp<Vector256<T>> lookup<T>(N256 w, ULK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return vnot;
                case ULK.Identity: return videntity;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        public static BinaryOp<Vector128<T>> lookup<T>(N128 w,BCK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return veq;
                case BCK.Lt: return vlt;
                case BCK.Gt: return vgt;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        public static BinaryOp<Vector256<T>> lookup<T>(N256 w, BCK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return veq;
                case BCK.Lt: return vlt;
                case BCK.Gt: return vgt;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        public static Shifter<Vector128<T>> lookup<T>(N128 w, BSK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BSK.Sll: return vsll;
                case BSK.Srl: return vsrl;
                case BSK.Rotl: return vrotl;
                case BSK.Rotr: return vrotr;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        public static Shifter<Vector256<T>> lookup<T>(N256 w, BSK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BSK.Sll: return vsll;
                case BSK.Srl: return vsrl;
                case BSK.Rotl: return vrotl;
                case BSK.Rotr: return vrotr;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates an identified unary operator over a supplied operand
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <param name="a">The operand</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(Integers)]
        public static Vector128<T> eval<T>(ULK kind, Vector128<T> a)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return vnot(a);
                case ULK.Identity: return videntity(a);
                case ULK.False: return vfalse(a);
                case ULK.True: return vtrue(a);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates a comparison operator over supplied operands
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(AllNumeric)]
        public static Vector128<T> eval<T>(BCK kind, Vector128<T> a, Vector128<T> b)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return veq(a,b);
                case BCK.Lt: return vlt(a,b);
                case BCK.Gt: return vgt(a,b);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates an identified shift operator over supplied operands
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <param name="a">The subject</param>
        /// <param name="count">The shift bit count</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(UnsignedInts)]
        public static Vector128<T> eval<T>(BSK kind, Vector128<T> a, [Imm] byte count)
            where T : unmanaged
        {
            switch(kind)
            {
                case BSK.Sll: return vsll(a,count);
                case BSK.Srl: return vsrl(a,count);
                case BSK.Rotl: return vrotl(a,count);
                case BSK.Rotr: return vrotr(a,count);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(AllNumeric)]
        public static Vector128<T> eval<T>(BAR kind, Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            switch(kind)
            {
                case BAR.Add: return vadd(x,y);
                case BAR.Sub: return vsub(x,y);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates an identified binary bitwise operator over supplied operands
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(Integers)]
        public static Vector128<T> eval<T>(BLK kind, Vector128<T> a, Vector128<T> b)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return vtrue(a,b);
                case BLK.False: return vfalse(a,b);
                case BLK.And: return vand(a,b);
                case BLK.Nand: return vnand(a,b);
                case BLK.Or: return vor(a,b);
                case BLK.Nor: return vnor(a,b);
                case BLK.Xor: return vxor(a,b);
                case BLK.Xnor: return vxnor(a,b);
                case BLK.Left: return vleft(a,b);
                case BLK.Right: return vright(a,b);
                case BLK.LNot: return vlnot(a,b);
                case BLK.RNot: return vrnot(a,b);
                case BLK.Impl: return vimpl(a,b);
                case BLK.NonImpl: return vnonimpl(a,b);
                case BLK.CImpl: return vcimpl(a,b);
                case BLK.CNonImpl: return vcnonimpl(a,b);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(Integers)]
        public static BinaryOp<Vector128<T>> lookup<T>(N128 w, BLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return vtrue;
                case BLK.False: return vfalse;
                case BLK.And: return vand;
                case BLK.Nand: return vnand;
                case BLK.Or: return vor;
                case BLK.Nor: return vnor;
                case BLK.Xor: return vxor;
                case BLK.Xnor: return vxnor;
                case BLK.Left: return vleft;
                case BLK.Right: return vright;
                case BLK.LNot: return vlnot;
                case BLK.RNot: return vrnot;
                case BLK.Impl: return vimpl;
                case BLK.NonImpl: return vnonimpl;
                case BLK.CImpl: return vcimpl;
                case BLK.CNonImpl: return vcnonimpl;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates an ternary operator over supplied operands
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        [Op, Closures(Integers)]
        public static Vector128<T> eval<T>(TLK kind, Vector128<T> x, Vector128<T> y, Vector128<T> z)
            where T : unmanaged
                => lookup<T>(n128,kind)(x,y,z);

        /// <summary>
        /// Returns a kind-identified delegate if possible; otherwise, raises an exception
        /// </summary>
        /// <param name="kind">The operator kind</param>
        /// <typeparam name="T">The primal vector component type</typeparam>
        public static TernaryOp<Vector128<T>> lookup<T>(N128 w, TLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case TLK.X01: return f01;
                case TLK.X02: return f02;
                case TLK.X03: return f03;
                case TLK.X04: return f04;
                case TLK.X05: return f05;
                case TLK.X06: return f06;
                case TLK.X07: return f07;
                case TLK.X08: return f08;
                case TLK.X09: return f09;
                case TLK.X0A: return f0a;
                case TLK.X0B: return f0b;
                case TLK.X0C: return f0c;
                case TLK.X0D: return f0d;
                case TLK.X0E: return f0e;
                case TLK.X0F: return f0f;
                case TLK.X10: return f10;
                case TLK.X11: return f11;
                case TLK.X12: return f12;
                case TLK.X13: return f13;
                case TLK.X14: return f14;
                case TLK.X15: return f15;
                case TLK.X16: return f16;
                case TLK.X17: return f17;
                case TLK.X18: return f18;
                case TLK.X19: return f19;
                case TLK.X1A: return f1a;
                case TLK.X1B: return f1b;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        // a nor (b or c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f01<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
            => vnor(a, vor(b,c));

        // c and (b nor a)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f02<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(c, vnor(b,a));

         // b nor a
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f03<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(b,a);

       // b and (a nor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f04<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(b, vnor(a,c));

        // c nor a
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f05<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(c,a);

        // not a and (b xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f06<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(a), vxor(b,c));

        // not a and (b xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f07<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(a, vand(b,c));

        // (not a and b) and c
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f08<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vand(vnot(a),b), c);

        // a nor (b xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f09<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(a, vxor(b,c));

        // c and (not a)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0a<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(c, vnot(a));

        // not a and ((b xor 1) or c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0b<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(a), vor(vnot(b),  c));

        // b and (not a)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0c<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(b, vnot(a));

        // not a and (b or (c xor 1))
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0d<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(a), vor(b, vnot(c)));

        // not a and (b or c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0e<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(a), vor(b,c));

        // not a
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f0f<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnot(a);

        // a and (b nor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f10<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(a, vnor(b, c));

        // c nor b
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f11<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(c,b);

        // not b and (a xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f12<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(b), vxor(a,c));

        // b nor (a and c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f13<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(b, vand(a,c));

        // not c and (a xor b)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f14<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vnot(c), vxor(a,b));

        // c nor (b and a)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f15<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnor(c, vand(a,b));

        // a ? (b nor c) : (b xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f16<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vselect(a, vnor(b,c), vxor(b,c));

        // not(a ? (b or c) : (b and c))
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f17<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnot(vselect(a, vor(b,c), vand(b,c)));

        // (a xor b) and (a xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f18<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vand(vxor(a,b), vxor(a,c));

        // ((b xor c) xor (a and (b and c))
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f19<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vxor(vxor(b,c), vand(a, vand(b,c)));

        // not ((a and b)) and (a xor c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f1a<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vnot(vand(vand(a,b), vxor(a, c)));

        // c ? not a : not b
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f1b<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vselect(c, vnot(a), vnot(b));

        // a ? (b xnor c) : (b nand c)
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> f97<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
                => vselect(c, vxnor(b,c), vnand(b,c));
    }
}