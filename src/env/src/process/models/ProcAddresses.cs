//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public readonly struct ProcAddresses
{
    readonly Index<Address16> _Selectors;

    readonly Index<List<Paired<Address32,uint>>> _Bases;

    readonly Index<ProcessSegment> _Segments;

    public ProcAddresses(Index<ProcessSegment> segments, Index<Address16> selectors, Index<List<Paired<Address32,uint>>> bases)
    {
        _Segments = segments;
        _Selectors = selectors;
        _Bases =  bases;
    }

    public ReadOnlySpan<ProcessSegment> Segments
    {
        [MethodImpl(Inline)]
        get => _Segments.View;
    }

    public ByteSize Traverse(MemoryAddress @base, FolderPath dst)
        => new ProcessSegments(@base, dst).Traverse(Segments);

    public uint SegmentCount
    {
        [MethodImpl(Inline)]
        get => _Segments.Count;
    }

    public ushort SelectorCount
    {
        [MethodImpl(Inline)]
        get => (ushort)_Selectors.Count;
    }

    public ReadOnlySpan<Paired<Address32,uint>> Bases(ushort index)
        => _Bases[index].ViewDeposited();

    [MethodImpl(Inline)]
    public Address16 Selector(ushort index)
        => _Selectors[index];

    [MethodImpl(Inline)]
    public int SelectorIndex(Address16 selector)
    {
        var count = SelectorCount;
        var src = _Selectors.View;
        for(var i=0; i<count; i++)
        {
            if(skip(src,i) == selector)
                return i;
        }
        return NotFound;
    }
}
