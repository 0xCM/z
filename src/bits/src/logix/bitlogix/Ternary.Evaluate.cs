//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitLogix;

    using TLK = TernaryBitLogicKind;

    partial class BitLogixOps
    {
        /// <summary>
        /// Evaluates an identified ternary operator
        /// </summary>
        /// <param name="op">The ternary operator classifier</param>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [Op]
        public static bit eval(TLK kind, bit a, bit b, bit c)
        {
            switch(kind)
            {
                case TLK.X00: return @false(a,b,c);
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
                case TLK.XCA: return select(a, b, c);
                case TLK.XFF: return f5a(a, b, c);
                default: return Unsupported.raise<bit>();
            }
        }
    }
}