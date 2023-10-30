//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static RegClasses;

partial struct AsmRegs
{
    public static AsmRegName name<T>(T src)
        where T : unmanaged, IRegOp
            => name(src.Size, src.RegClassCode, src.IndexCode);

    public static AsmRegName name(NativeSizeCode size, RegClassCode @class, RegIndexCode index)
    {
        var i = (byte)index;
        switch(@class)
        {
            case RegClassCode.GP:
                return Gp.RegName(i, size);
            case RegClassCode.XMM:
                return Xmm.RegName(i);
            case RegClassCode.YMM:
                return Ymm.RegName(i);
            case RegClassCode.ZMM:
                return Zmm.RegName(i);
            case RegClassCode.MASK:
                return KReg.RegName(i);
            case RegClassCode.MMX:
                return Mmx.RegName(i);
            case RegClassCode.DB:
                return Db.RegName(i);
            case RegClassCode.CR:
                return Cr.RegName(i);
            case RegClassCode.TR:
                return Tr.RegName(i);
            case RegClassCode.ST:
                return St.RegName(i);
            case RegClassCode.SEG:
                return Seg.RegName(i);
            case RegClassCode.BND:
                return Bnd.RegName(i);
            case RegClassCode.IPTR:
                return IP.RegName(size);
            case RegClassCode.FLAG:
                return Flag.RegName(size);
        }
        return asci8.Null;
    }
}
