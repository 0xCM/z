//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;
    using static BitLogix;

    using TLK = TernaryBitLogicKind;

    partial class BitLogixOps
    {
        /// <summary>
        /// Returns a kind-identified ternary operator
        /// </summary>
        /// <param name="kind">The operator kind</param>
        [Op]
        public static TernaryOp<bit> lookup(TLK kind)
        {
            switch(kind)
            {
                case TLK.X00: return @false;
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
                case TLK.XFF: return @true;

                default: throw Unsupported.value(sig(kind));
            }
        }
    }
}