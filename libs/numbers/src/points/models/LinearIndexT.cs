//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LinearIndex<T>
        where T : unmanaged
    {
        readonly Index<Point<T>> Data;

        [MethodImpl(Inline)]
        public LinearIndex(Point<T>[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref Point<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref Point<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public static implicit operator LinearIndex<T>(Point<T>[] src)
            => new LinearIndex<T>(src);
    }
}