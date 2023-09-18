//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public record struct EncodingOffsets
{
    public sbyte OpCode;

    public sbyte ModRm;

    public sbyte Sib;

    public sbyte Imm0;

    public sbyte Imm1;

    public sbyte Disp;

    public bool HasOpCode
    {
        [MethodImpl(Inline)]
        get => OpCode >= 0;
    }

    public bool HasModRm
    {
        [MethodImpl(Inline)]
        get => ModRm >= 0;
    }

    public bool HasSib
    {
        [MethodImpl(Inline)]
        get => Sib >= 0;
    }

    public bool HasImm0
    {
        [MethodImpl(Inline)]
        get => Imm0 >= 0;
    }

    public bool HasImm1
    {
        [MethodImpl(Inline)]
        get => Imm1 >= 0;
    }

    public bool HasDisp
    {
        [MethodImpl(Inline)]
        get => Disp >= 0;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => OpCode < 0 && ModRm < 0 && Sib < 0 && Imm0 < 0 && Imm1 < 0 && Disp < 0;
    }

    [MethodImpl(Inline)]
    static EncodingOffsets empty()
    {
        var dst = new EncodingOffsets();
        dst.OpCode = -1;
        dst.ModRm = -1;
        dst.Sib = -1;
        dst.Imm0 = -1;
        dst.Imm1 = -1;
        dst.Disp = -1;
        return dst;
    }

    public string Format()
        => Asm.asm.format(this);

    public override string ToString()
        => Format();
        
    public static EncodingOffsets Empty
    {
        [MethodImpl(Inline)]
        get => empty();
    }
}
