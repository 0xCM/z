//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PointMapper<I,T>
        where I : unmanaged
        where T : unmanaged
    {
        readonly Index<I,Paired<I,T>> Storage;

        public PointMapper(Paired<I,T>[] maps)
        {
            Storage = maps;
        }

        [MethodImpl(Inline)]
        public ref Paired<I,T> Map(I index)
            => ref Storage[index];

        public ref Paired<I,T> this[I index]
        {
            [MethodImpl(Inline)]
            get => ref Map(index);
        }

        public Span<Paired<I,T>> Points
        {
            [MethodImpl(Inline)]
            get => Storage.Edit;
        }

        public uint PointCount
        {
            [MethodImpl(Inline)]
            get => Storage.Count;
        }
    }
}