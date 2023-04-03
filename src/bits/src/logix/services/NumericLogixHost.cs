//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static LogicSig;
    using static NumericLogixOps;

    using BLK = BinaryBitLogicKind;
    using TLK = TernaryBitLogicKind;
    using ULK = UnaryBitLogicKind;
    using UAR = ApiUnaryArithmeticClass;
    using BAR = ApiBinaryArithmeticClass;
    using BCK = ApiComparisonClass;
    using BSK = BitShiftClass;

    [ApiHost]
    public readonly struct NumericLogixHost
    {
        /// <summary>
        /// Advertises the supported unary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<ULK> UnaryLogicKinds
            => Enums.literals<ULK>();

        /// <summary>
        /// Advertises the supported binary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<BLK> BinaryLogicKinds
            => Enums.literals<BLK>();

        /// <summary>
        /// Advertises the supported ternary bitlogic operators
        /// </summary>
        public static ReadOnlySpan<TLK> TernaryLogicKinds
            => gcalc.stream((byte)1,(byte)TLK.X5F).Cast<TLK>().ToArray();

        /// <summary>
        /// Advertises the supported unary arithmetic operators
        /// </summary>
        public static ReadOnlySpan<UAR> UnaryAritmeticKinds
            => Enums.literals<UAR>();

        /// <summary>
        /// Advertises the supported binary arithmetic operators
        /// </summary>
        public static ReadOnlySpan<BAR> BinaryArithmeticKinds
            => Enums.literals<BAR>();

        /// <summary>
        /// Advertises the supported comparison operators
        /// </summary>
        public static ReadOnlySpan<BCK> BinaryComparisonKinds
            => Enums.literals<BCK>();

        [Op, Closures(Integers)]
        public static bit eval<T>(BCK kind, T a, T b)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return gmath.eq(a,b);
                case BCK.Neq: return gmath.neq(a,b);
                case BCK.Lt: return gmath.lt(a,b);
                case BCK.LtEq: return gmath.lteq(a,b);
                case BCK.Gt: return gmath.gt(a,b);
                case BCK.GtEq: return gmath.gteq(a,b);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(Integers)]
        public static BinaryPredicate<T> lookup<T>(BCK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BCK.Eq: return gmath.eq;
                case BCK.Neq: return gmath.neq;
                case BCK.Lt: return gmath.lt;
                case BCK.LtEq: return gmath.lteq;
                case BCK.Gt: return gmath.gt;
                case BCK.GtEq: return gmath.gteq;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(Integers)]
        public static T eval<T>(BLK kind, T a, T b)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return @true(a,b);
                case BLK.False: return @false(a,b);
                case BLK.And: return and(a,b);
                case BLK.Nand: return nand(a,b);
                case BLK.Or: return or(a,b);
                case BLK.Nor: return nor(a,b);
                case BLK.Xor: return xor(a,b);
                case BLK.Xnor: return xnor(a,b);
                case BLK.Left: return left(a,b);
                case BLK.Right: return right(a,b);
                case BLK.LNot: return lnot(a,b);
                case BLK.RNot: return rnot(a,b);
                case BLK.Impl: return impl(a,b);
                case BLK.NonImpl: return nonimpl(a,b);
                case BLK.CImpl: return cimpl(a,b);
                case BLK.CNonImpl: return cnonimpl(a,b);
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        [Op, Closures(Integers)]
        public static T eval<T>(ULK kind, T a)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return not(a);
                case ULK.Identity: return identity(a);
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        /// <summary>
        /// Evaluates an identified ternary operator
        /// </summary>
        /// <param name="op">The ternary operator classifier</param>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [Op, Closures(Integers)]
        public static T eval<T>(TLK kind, T a, T b, T c)
            where T : unmanaged
        {
            switch(kind)
            {
                case TLK.X01: return f01(a, b, c);
                case TLK.X02: return f02(a, b, c);
                case TLK.X03: return f03(a, b, c);
                case TLK.X04: return f04(a, b, c);
                case TLK.X05: return f05(a, b, c);
                case TLK.X06: return f06(a, b, c);
                case TLK.X07: return f07(a, b, c);
                case TLK.X08: return f08(a, b, c);
                case TLK.X09: return f09(a, b, c);
                case TLK.X0A: return f0a(a, b, c);
                case TLK.X0B: return f0b(a, b, c);
                case TLK.X0C: return f0c(a, b, c);
                case TLK.X0D: return f0d(a, b, c);
                case TLK.X0E: return f0e(a, b, c);
                case TLK.X0F: return f0f(a, b, c);
                case TLK.X10: return f10(a, b, c);
                case TLK.X11: return f11(a, b, c);
                case TLK.X12: return f12(a, b, c);
                case TLK.X13: return f13(a, b, c);
                case TLK.X14: return f14(a, b, c);
                case TLK.X15: return f15(a, b, c);
                case TLK.X16: return f16(a, b, c);
                case TLK.X17: return f17(a, b, c);
                case TLK.X18: return f18(a, b, c);
                case TLK.X19: return f19(a, b, c);
                case TLK.X1A: return f1a(a, b, c);
                case TLK.X1B: return f1b(a, b, c);
                case TLK.X1C: return f1c(a, b, c);
                case TLK.X1D: return f1d(a, b, c);
                case TLK.X1E: return f1e(a, b, c);
                case TLK.X1F: return f1f(a, b, c);
                case TLK.X20: return f20(a, b, c);
                case TLK.X21: return f21(a, b, c);
                case TLK.X22: return f22(a, b, c);
                case TLK.X23: return f23(a, b, c);
                case TLK.X24: return f24(a, b, c);
                case TLK.X25: return f25(a, b, c);
                case TLK.X26: return f26(a, b, c);
                case TLK.X27: return f27(a, b, c);
                case TLK.X28: return f28(a, b, c);
                case TLK.X29: return f29(a, b, c);
                case TLK.X2A: return f2a(a, b, c);
                case TLK.X2B: return f2b(a, b, c);
                case TLK.X2C: return f2c(a, b, c);
                case TLK.X2D: return f2d(a, b, c);
                case TLK.X2E: return f2e(a, b, c);
                case TLK.X2F: return f2f(a, b, c);
                case TLK.X30: return f30(a, b, c);
                case TLK.X31: return f31(a, b, c);
                case TLK.X32: return f32(a, b, c);
                case TLK.X33: return f33(a, b, c);
                case TLK.X34: return f34(a, b, c);
                case TLK.X35: return f35(a, b, c);
                case TLK.X36: return f36(a, b, c);
                case TLK.X37: return f37(a, b, c);
                case TLK.X38: return f38(a, b, c);
                case TLK.X39: return f39(a, b, c);
                case TLK.X3A: return f3a(a, b, c);
                case TLK.X3B: return f3b(a, b, c);
                case TLK.X3C: return f3c(a, b, c);
                case TLK.X3D: return f3d(a, b, c);
                case TLK.X3E: return f3e(a, b, c);
                case TLK.X3F: return f3f(a, b, c);
                case TLK.X40: return f40(a, b, c);
                case TLK.X41: return f41(a, b, c);
                case TLK.X42: return f42(a, b, c);
                case TLK.X43: return f43(a, b, c);
                case TLK.X44: return f44(a, b, c);
                case TLK.X45: return f45(a, b, c);
                case TLK.X46: return f46(a, b, c);
                case TLK.X47: return f47(a, b, c);
                case TLK.X48: return f48(a, b, c);
                case TLK.X49: return f49(a, b, c);
                case TLK.X4A: return f4a(a, b, c);
                case TLK.X4B: return f4b(a, b, c);
                case TLK.X4C: return f4c(a, b, c);
                case TLK.X4D: return f4d(a, b, c);
                case TLK.X4E: return f4e(a, b, c);
                case TLK.X4F: return f4f(a, b, c);
                case TLK.X50: return f50(a, b, c);
                case TLK.X51: return f51(a, b, c);
                case TLK.X52: return f52(a, b, c);
                case TLK.X53: return f53(a, b, c);
                case TLK.X54: return f54(a, b, c);
                case TLK.X55: return f55(a, b, c);
                case TLK.X56: return f56(a, b, c);
                case TLK.X57: return f57(a, b, c);
                case TLK.X58: return f58(a, b, c);
                case TLK.X59: return f59(a, b, c);
                case TLK.X5A: return f5a(a, b, c);
                case TLK.X5B: return f5b(a, b, c);
                case TLK.X5C: return f5c(a, b, c);
                case TLK.X5D: return f5d(a, b, c);
                case TLK.X5E: return f5e(a, b, c);
                case TLK.X5F: return f5f(a, b, c);
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        [Op, Closures(UnsignedInts)]
        public static T eval<T>(BSK kind, T a, byte count)
            where T : unmanaged
        {
            switch(kind)
            {
                case BSK.Sll: return sll(a, count);
                case BSK.Srl: return srl(a, count);
                case BSK.Rotl: return rotl(a, count);
                case BSK.Rotr: return rotr(a, count);
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        [Op, Closures(Integers)]
        public static Shifter<T> lookup<T>(BSK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BSK.Sll: return sll;
                case BSK.Srl: return srl;
                case BSK.Rotl: return rotl;
                case BSK.Rotr: return rotr;
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        [Op, NumericClosures(Integers)]
        public static UnaryOp<T> lookup<T>(ULK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return not;
                case ULK.Identity: return identity;
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        public static BinaryOp<T> lookup<T>(BLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return @true;
                case BLK.False: return @false;
                case BLK.And: return and;
                case BLK.Nand: return nand;
                case BLK.Or: return or;
                case BLK.Nor: return nor;
                case BLK.Xor: return xor;
                case BLK.Xnor: return xnor;
                case BLK.Left: return left;
                case BLK.Right: return right;
                case BLK.LNot: return lnot;
                case BLK.RNot: return rnot;
                case BLK.Impl: return impl;
                case BLK.NonImpl: return nonimpl;
                case BLK.CImpl: return cimpl;
                case BLK.CNonImpl: return cnonimpl;
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }

        public static TernaryOp<T> lookup<T>(TLK kind)
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
                case TLK.X1C: return f1c;
                case TLK.X1D: return f1d;
                case TLK.X1E: return f1e;
                case TLK.X1F: return f1f;
                case TLK.X20: return f20;
                case TLK.X21: return f21;
                case TLK.X22: return f22;
                case TLK.X23: return f23;
                case TLK.X24: return f24;
                case TLK.X25: return f25;
                case TLK.X26: return f26;
                case TLK.X27: return f27;
                case TLK.X28: return f28;
                case TLK.X29: return f29;
                case TLK.X2A: return f2a;
                case TLK.X2B: return f2b;
                case TLK.X2C: return f2c;
                case TLK.X2D: return f2d;
                case TLK.X2E: return f2e;
                case TLK.X2F: return f2f;
                case TLK.X30: return f30;
                case TLK.X31: return f31;
                case TLK.X32: return f32;
                case TLK.X33: return f33;
                case TLK.X34: return f34;
                case TLK.X35: return f35;
                case TLK.X36: return f36;
                case TLK.X37: return f37;
                case TLK.X38: return f38;
                case TLK.X39: return f39;
                case TLK.X3A: return f3a;
                case TLK.X3B: return f3b;
                case TLK.X3C: return f3c;
                case TLK.X3D: return f3d;
                case TLK.X3E: return f3e;
                case TLK.X3F: return f3f;
                case TLK.X40: return f40;
                case TLK.X41: return f41;
                case TLK.X42: return f42;
                case TLK.X43: return f43;
                case TLK.X44: return f44;
                case TLK.X45: return f45;
                case TLK.X46: return f46;
                case TLK.X47: return f47;
                case TLK.X48: return f48;
                case TLK.X49: return f49;
                case TLK.X4A: return f4a;
                case TLK.X4B: return f4b;
                case TLK.X4C: return f4c;
                case TLK.X4D: return f4d;
                case TLK.X4E: return f4e;
                case TLK.X4F: return f4f;
                case TLK.X50: return f50;
                case TLK.X51: return f51;
                case TLK.X52: return f52;
                case TLK.X53: return f53;
                case TLK.X54: return f54;
                case TLK.X55: return f55;
                case TLK.X56: return f56;
                case TLK.X57: return f57;
                case TLK.X58: return f58;
                case TLK.X59: return f59;
                case TLK.X5A: return f5a;
                case TLK.X5B: return f5b;
                case TLK.X5C: return f5c;
                case TLK.X5D: return f5d;
                case TLK.X5E: return f5e;
                case TLK.X5F: return f5f;
                default: throw new NotSupportedException(sig<T>(kind));
            }
        }
    }
}