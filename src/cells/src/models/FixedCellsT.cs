//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public ref struct FixedCells<T>
        where T : unmanaged
    {
        readonly Span<T> Storage;

        public FixedCells()
        {
            Storage = sys.empty<T>();
        }

        [MethodImpl(Inline)]
        public FixedCells(Span<T> src)
        {
            Storage = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator FixedCells<T>(T[] src)
            => new FixedCells<T>(src);
    }
}