//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using W = W32;
using I = Imm32;

/// <summary>
/// Defines a 32-bit immediate value
/// </summary>
public readonly struct Imm32 : IImm<I,uint>
{
    public uint Value {get;}

    [MethodImpl(Inline)]
    public Imm32(uint src)
        => Value = src;

    public AsmOpClass OpClass
    {
        [MethodImpl(Inline)]
        get => AsmOpClass.Imm;
    }

    public ImmKind ImmKind
        => ImmKind.Imm32u;

    public AsmOpKind OpKind
        => AsmOpKind.Imm32;

    public NativeSize Size
        => NativeSizeCode.W32;

    public string Format()
            => Imm.format(this);

    public override string ToString()
        => Format();

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Value;
    }

    public override int GetHashCode()
        => (int)Hash;

    [MethodImpl(Inline)]
    public int CompareTo(I src)
        => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

    [MethodImpl(Inline)]
    public bool Equals(I src)
        => Value == src.Value;

    public override bool Equals(object src)
        => src is I x && Equals(x);

    [MethodImpl(Inline)]
    public Address32 ToAddress()
        => Value;

    [MethodImpl(Inline)]
    public static bool operator <(I a, I b)
        => a.Value < b.Value;

    [MethodImpl(Inline)]
    public static bool operator >(I a, I b)
        => a.Value > b.Value;

    [MethodImpl(Inline)]
    public static bool operator <=(I a, I b)
        => a.Value <= b.Value;

    [MethodImpl(Inline)]
    public static bool operator >=(I a, I b)
        => a.Value >= b.Value;

    [MethodImpl(Inline)]
    public static bool operator ==(I a, I b)
        => a.Value == b.Value;

    [MethodImpl(Inline)]
    public static bool operator !=(I a, I b)
        => a.Value != b.Value;

    [MethodImpl(Inline)]
    public static implicit operator uint(I src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator Imm<uint>(I src)
        => new Imm<uint>(src);

    [MethodImpl(Inline)]
    public static implicit operator I(uint src)
        => new I(src);

    [MethodImpl(Inline)]
    public static implicit operator Imm(I src)
        => new Imm(src.ImmKind, src.Value);

    public static W W => default;
}
