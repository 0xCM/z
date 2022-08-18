//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MemorySections;

    [Free]
    public interface ISectionDispenser
    {
        uint EntryCount {get;}

        Section Entry(ushort id);

        ReadOnlySpan<Section> Entries();
    }

    [Free]
    public interface ISectionDispenser<T> : ISectionDispenser
        where T : ISectionDispenser<T>
    {

    }
}