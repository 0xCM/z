//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmOpCodeTokens;

/// <summary>
/// [Index:[00000] | Token:[000]]
/// </summary>
public readonly record struct RexB
{
    readonly byte Value;

    [MethodImpl(Inline)]
    public RexB(RexBToken token, RegIndexCode r)
    {
        Value = math.or((byte)token, math.sll((byte)r,2));
    }

    public BpExpr BitPattern => $"{(RexBToken)(Value & 0b111)}";
    
    public bit Enabled
    {
        [MethodImpl(Inline)]
        get => math.le((byte)Token, (byte)RexBToken.ro);
    }

    public RexBToken Token
    {
        [MethodImpl(Inline)]
        get => (RexBToken)((byte)Value & 0b11);
    }

    public RegIndex Reg
    {
        [MethodImpl(Inline)]
        get => (math.srl((byte)Value,2) & 0b11111);
    }

    public NativeSize RegSize
    {
        [MethodImpl(Inline)]
        get => (NativeSizeCode)Token;
    }
}
