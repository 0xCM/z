//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// ModRM[mod[7:6] | reg[5:3] | r/m[2:0]]
/// </summary>
[StructLayout(LayoutKind.Sequential,Size=1)]
public record struct ModRm : IAsmByte<ModRm>, IBitPattern<ModRm>
{

    const uint mmMask=0b11000000;
    
    const byte mmMinPos=6;
    
    const uint rrrMask=0b00111000;
    
    const byte rrrMinPos=3;
    
    const uint nnnMask=0b00000111;
    
    const byte nnnMinPos=0;

    ref byte Value
    {
        [UnscopedRef, MethodImpl(Inline)]
        get => ref sys.@as<ModRm,byte>(this);
    }

    [MethodImpl(Inline)]
    public ModRm(byte value)
    {
        Value = value;
    }

    // mm[7:6]
    [MethodImpl(Inline)]
    public num2 mm()
        => (num2)((Value & mmMask) >> mmMinPos);

    [MethodImpl(Inline)]
    public void mm(num2 mm)
    {
        Value |= (byte)((uint)mm << mmMinPos);
    }

    // rrr[5:3]
    [MethodImpl(Inline)]
    public num3 rrr()
        => (num3)((Value & rrrMask) >> rrrMinPos);

    [MethodImpl(Inline)]
    public void rrr(num3 rrr)
    {
        Value |= (byte)((uint)rrr << rrrMinPos);
    }

    /// <summary>
    /// nnn[2:0]
    /// </summary>
    [MethodImpl(Inline)]
    public num3 nnn()
        => (num3)((Value & nnnMask) >> nnnMinPos);

    /// <summary>
    /// nnn[2:0]
    /// </summary>
    [MethodImpl(Inline)]
    public void nnm(num3 nnm)
    {
        Value |= (byte)((uint)nnm << nnnMinPos);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => (byte)Value;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Value != 0;
    }

    public bool IsZero
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => Value != 0;
    }

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public bool Equals(ModRm src)
        => Value == src.Value;

    public string Bitstring()
        => string.Format("{0} {1} {2}", mm().Bitstring(), rrr().Bitstring(), nnn().Bitstring());

    byte IAsmByte.Value()
        => Value;

    public string Format()
        => AsmBytes.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator ModRm(byte src)
        => new(src);

    [MethodImpl(Inline)]
    public static implicit operator byte(ModRm src)
        => src.Value;
}
