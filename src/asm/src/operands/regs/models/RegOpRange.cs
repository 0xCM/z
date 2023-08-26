//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public struct RegOpRange : IAsmOpSource<RegOp>
{
    readonly RegClass Class;

    readonly NativeSize Size;

    readonly byte Min;

    readonly byte Max;

    byte Current;

    [MethodImpl(Inline)]
    public RegOpRange(RegClass @class, NativeSize size, RegIndex min, RegIndex max)
    {
        Class = @class;
        Size = size;
        Min = (byte)min;
        Max = (byte)max;
        Current = 0;
        OpCount = (byte)((byte)max - (byte)min + 1);
    }

    public byte OpCount {get;}

    public AsmOpClass OpClass
    {
        [MethodImpl(Inline)]
        get => AsmOpClass.Reg;
    }

    public AsmOpKind OpKind
    {
        [MethodImpl(Inline)]
        get => asm.opkind(AsmOpClass.Reg,Size);
    }

    [MethodImpl(Inline)]
    public RegOp Next()
    {
        Next(out var dst);
        return dst;
    }

    [MethodImpl(Inline)]
    public bool Next(out RegOp dst)
    {
        if(Current < Max)
        {
            dst = AsmRegs.reg(Size, Class, (RegIndex) Current++);
            return true;
        }
        else
        {
            dst = RegOp.Empty;
            return false;
        }
    }
}
