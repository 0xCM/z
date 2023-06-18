//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Record(TableId), StructLayout(LayoutKind.Sequential)]
public record struct MethodSegment
{
    const string TableId = "method.segments";

    [Render(16)]
    public uint MethodIndex;

    [Render(16)]
    public MemoryAddress EntryPoint;

    [Render(16)]
    public uint SegIndex;

    [Render(16)]
    public Address16 SegSelector;

    [Render(16)]
    public ByteSize SegSize;

    [Render(16)]
    public MemoryAddress SegStart;

    [Render(16)]
    public MemoryAddress SegEnd;

    [Render(1)]
    public utf8 Uri;
}
