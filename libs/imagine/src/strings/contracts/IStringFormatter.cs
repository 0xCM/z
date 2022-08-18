//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IStringFormatter
    {
        string Format(ReadOnlySpan<byte> src);
    }

    [Free]
    public interface IStringFormatter<K> : IStringFormatter
        where K : unmanaged
    {
        string Format(ReadOnlySpan<K> src);

        string IStringFormatter.Format(ReadOnlySpan<byte> src)
            => Format(Spans.recover<K>(src));
    }
}