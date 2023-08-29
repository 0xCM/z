//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public struct RingStream<I,T>
{
    Index<T> Data;

    ulong Pos;

    ulong Count;

    [MethodImpl(Inline)]
    public RingStream(Index<T> src)
    {
        Data = src;
        Pos = 0;
        Count = (ulong)src.Length;
    }

    [MethodImpl(Inline)]
    public T Next()
    {
        if(Pos >= Count)
            Pos = 0;

        return Data[Pos++];
    }

    [MethodImpl(Inline)]
    public ReadOnlySpan<T> TryRead(I wanted, out I actual)
    {
        var length = uint64(wanted);
        if(Pos + length < Count)
        {
            var take = slice(Data.View, Pos, Count);
            actual = wanted;
            Pos += Count;
            return take;
        }
        else
        {
            var available = Count - Pos;
            var take = slice(Data.View, Pos, available);
            actual = @as<ulong,I>(available);
            Pos = 0;
            return take;
        }
    }
}
