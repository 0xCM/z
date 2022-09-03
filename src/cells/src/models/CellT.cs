//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct Cell<T> : IDataCell<Cell<T>>
        where T : unmanaged
    {
        T Content;

        [MethodImpl(Inline)]
        public Cell(T src)
            => Content = src;

        [MethodImpl(Inline)]
        public string Format()
            => Content.ToString();

        [MethodImpl(Inline)]
        public static ref Cell<T> assign(in T src, ref Cell<T> dst)
        {
            dst.Content = src;
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref Cell<S> morph<S>(in Cell<T> src)
            where S : unmanaged
                => ref @as<Cell<T>,Cell<S>>(src);

        [MethodImpl(Inline)]
        public static T operator !(in Cell<T> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator T(in Cell<T> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator Cell<T>(in T src)
            => new Cell<T>(src);
    }
}