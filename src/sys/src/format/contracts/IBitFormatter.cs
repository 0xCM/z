//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitFormatter
    {
        string Format(ReadOnlySpan<byte> src);
    }

    public interface IBitFormatter<T> : ITargetedBitFormatter<T>
        where T : struct
    {
        string Format(T src);
    }
}