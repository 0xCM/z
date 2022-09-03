//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LogicChannels
    {
        public readonly struct Not<T> : IChannel1x1<Not<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, out T y0)
                => y0 = gmath.not(x0);
        }

        public readonly struct And<T> : IChannel2x1<And<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, T x1, out T y0)
                => y0 = gmath.and(x0,x1);
        }

        public readonly struct Or<T> : IChannel2x1<Or<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, T x1, out T y0)
                => y0 = gmath.or(x0,x1);
        }

        public readonly struct Xor<T> : IChannel2x1<Xor<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, T x1, out T y0)
                => y0 = gmath.xor(x0,x1);
        }

        public readonly struct Xnor<T> : IChannel2x1<Xnor<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, T x1, out T y0)
                => y0 = gmath.xnor(x0,x1);
        }

        public readonly struct Nand<T> : IChannel2x1<Nand<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public void Send(T x0, T x1, out T y0)
                => y0 = gmath.nand(x0,x1);
        }
    }
}