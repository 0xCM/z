//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Comparator<T> : IChannel2x2<Comparator<T>,T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public void Send(T x0, T x1, out T y0, out T y1)
        {
            y0 = gmath.min(x0,x1);
            y1 = gmath.max(x0,x1);
        }
    }
}