//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public unsafe readonly record struct MemoryToken
{
    public readonly uint Index;

    public readonly MemoryAddress Location;

    public readonly uint Length;

    [MethodImpl(Inline)]
    public MemoryToken(uint index, MemoryAddress location, uint length)
    {
        Index = index;
        Location = location;
        Length = length;
    }

    public ReadOnlySpan<char> Expr
    {
        [MethodImpl(Inline)]
        get => cover(Location.Pointer<char>(), Length);
    }
    
    public ReadOnlySpan<char> Name 
    {
        [MethodImpl(Inline)]
        get => Location.Format();
    }

    public string Format()
        => sys.@string(Expr);

    public override string ToString()
        => Format();
}
