//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// ModRM[mod[7:6] | reg[5:3] | r/m[2:0]]
/// </summary>
[ApiComplete, DataWidth(8)]
public struct ModRm : IAsmByte<ModRm>
{
    public static ModRm init(byte src = 0)
        => new (src);

    [MethodImpl(Inline)]
    public static ModRm init(uint2 mod, uint3 reg, uint3 rm)
        => new (mod,reg,rm);

    byte _Value;

    public ModRm(byte src)
    {
        _Value = src;
    }

    [MethodImpl(Inline)]
    public ModRm(uint2 mod, uint3 reg, uint3 rm)
    {
        _Value = default;
        Mod(mod);
        Reg(reg);
        Rm(rm);
    }

    const byte RmMask = 0b11_111_000;

    const byte RmOffset = 0;

    const byte RegMask = 0b11_000_111;

    const byte RegOffset = 3;

    const byte ModMask = 0b00_111_111;

    const byte ModOffset = 6;

    [MethodImpl(Inline)]
    public uint3 Rm()
        => (uint3)(math.srl((byte)(_Value & ~RmMask), RmOffset));

    [MethodImpl(Inline)]
    public void Rm(uint3 src)
        => _Value = math.or(math.and(_Value, RmMask), math.sll(src,RmOffset));

    [MethodImpl(Inline)]
    public void Rm(RegIndexCode src)
        => _Value = math.or(math.and(_Value, RmMask), math.sll((byte)src, RmOffset));

    [MethodImpl(Inline)]
    public void Rm(byte src)
        => _Value = math.or(math.and(_Value, RmMask), math.sll(math.and(src,(byte)7) ,RmOffset));

    [MethodImpl(Inline)]
    public uint3 Reg()
        => (uint3)(math.srl((byte)(_Value & ~RegMask), RegOffset));

    [MethodImpl(Inline)]
    public void Reg(uint3 src)
        => _Value = math.or(math.and(_Value, RegMask),math.sll(src,RegOffset));

    [MethodImpl(Inline)]
    public void Reg(RegIndexCode src)
        => _Value = math.or(math.and(_Value, RegMask),math.sll((byte)src,RegOffset));

    [MethodImpl(Inline)]
    public void Reg(byte src)
        => _Value = math.or(math.and(_Value, RegMask),math.sll(math.and(src,(byte)7),RegOffset));

    [MethodImpl(Inline)]
    public uint2 Mod()
        => (uint2)(math.srl((byte)(_Value & ~ModMask), ModOffset));

    [MethodImpl(Inline)]
    public void Mod(uint2 src)
        => _Value = math.or(math.and(_Value, ModMask), math.sll(src,ModOffset));

    [MethodImpl(Inline)]
    public void Mod(byte src)
        => _Value = math.or(math.and(_Value, ModMask), math.sll(math.and(src,(byte)3),ModOffset));

    [MethodImpl(Inline)]
    public byte Value()
        => _Value;

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => _Value == 0;
    }

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => _Value != 0;
    }

    public string ToBitString()
        => string.Format("{0} {1} {2}", Mod(), Reg(), Rm());

    public string Format()
        => AsmPrefixByte.format(this);

    public override string ToString()
        => Format();

    public bool Equals(ModRm src)
        => _Value == src._Value;

    public override bool Equals(object src)
        => src is ModRm x && Equals(x);

    public override int GetHashCode()
        => _Value;

    [MethodImpl(Inline)]
    public static implicit operator byte(ModRm src)
        => src.Value();

    [MethodImpl(Inline)]
    public static explicit operator ModRm(byte src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator Hex8(ModRm src)
        => src.Value();

    public static bool operator ==(ModRm a, ModRm b)
        => a.Equals(b);

    public static bool operator !=(ModRm a, ModRm b)
        => !a.Equals(b);

    public static ModRm Empty => default;
}
