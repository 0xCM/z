//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct SortingNetwork<T>
    where T : unmanaged
{
    readonly Index<Comparator<T>> Channels;

    [MethodImpl(Inline)]
    internal SortingNetwork(Comparator<T>[] channels)
    {
        Channels = channels;
    }

    [MethodImpl(Inline)]
    ref readonly Comparator<T> Component(uint index)
        => ref Channels[index];

    ref readonly Comparator<T> this[uint index]
    {
        [MethodImpl(Inline)]
        get => ref Component(index);
    }

    [MethodImpl(Inline)]
    public void Send(T x0, T x1, T x2, T x3, out T y0, out T y1, out T y2, out T y3)
    {
        this[0].Send(x0, x1, out y0, out y1);
        this[1].Send(x2, x3, out y2, out y3);
        this[2].Send(y0, y2, out y0, out y2);
        this[3].Send(y1, y3, out y1, out y3);
        this[4].Send(y1, y2, out y1, out y2);
    }
}
