//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct AsmRip
{
    public readonly MemoryAddress Address;

    [MethodImpl(Inline)]
    public AsmRip(MemoryAddress callsite, byte instsize)
    {
        Address = callsite + instsize;
    }

    public string Format()
        => Address.Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator AsmRip((MemoryAddress call, byte instsize) src)
        => new AsmRip(src.call, src.instsize);

    [MethodImpl(Inline)]
    public static implicit operator MemoryAddress(AsmRip src)
        => src.Address;

    [MethodImpl(Inline)]
    public static explicit operator int(AsmRip src)
        => (int)src.Address;

    [MethodImpl(Inline)]
    public static explicit operator long(AsmRip src)
        => (long)src.Address;

    [MethodImpl(Inline)]
    public static explicit operator ulong(AsmRip src)
        => src.Address;
}
