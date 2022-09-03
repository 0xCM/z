//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MultiLinear<T>
        where T : unmanaged
    {
        readonly Index<MultiPoint<T>> Data;

        [MethodImpl(Inline)]
        public MultiLinear(MultiPoint<T>[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref MultiPoint<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref MultiPoint<T> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public static implicit operator MultiLinear<T>(MultiPoint<T>[] src)
            => new MultiLinear<T>(src);
    }
}