//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public readonly record struct RegSlot : IComparable<RegSlot>
{
    public readonly sbyte Index;

    public readonly NativeSize Size;

    [MethodImpl(Inline)]
    public RegSlot(sbyte index, NativeSize size)
    {
        Index = index;
        Size = size;
    }
    
    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => (Hash16)(byte)Index | (Hash16)(byte)Size;
    }
    
    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Index >= 0;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Index < 0;
    }

    public string Format()
        => IsNonEmpty ?  $"R{Size}:{Index}" : $"R{Size}:?";
        
    public override string ToString()
        => Format();
    
    public override int GetHashCode()
        => Hash;
    
    [MethodImpl(Inline)]
    public bool Equals(RegSlot src)
        => Index == src.Index && Size == src.Size;

    public int CompareTo(RegSlot src)
    {
        var result = Size.ByteCount.CompareTo(src.Size.ByteCount);
        if(result == 0)
            result = Index.CompareTo(src.Index);
        return result;
    }

    public static RegSlot Empty => new(-1,default);
}