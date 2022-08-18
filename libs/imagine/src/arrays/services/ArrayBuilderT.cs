//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ArrayBuilder;

    public readonly struct ArrayBuilder<T>
    {
        internal readonly List<T> Storage;

        [MethodImpl(Inline)]
        internal ArrayBuilder(int capacity)
            => Storage = new List<T>(capacity);

        [MethodImpl(Inline)]
        internal ArrayBuilder(params T[] src)
        {
            Storage = new List<T>();
            Storage.AddRange(src);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Storage.Count;
        }

        [MethodImpl(Inline)]
        public void Include(params T[] src)
            => Storage.AddRange(src);

        [MethodImpl(Inline)]
        public T[] Emit(bool clear = true)
            => api.emit(this, clear);

        [MethodImpl(Inline)]
        public void CopyTo(Span<T> dst)
            => api.copy(Storage,dst);

        /// <summary>
        /// Copies the accumulated items to the target beginning at a specified offset
        /// </summary>
        /// <param name="dst">The data target</param>
        /// <param name="offset">The target offset</param>
        [MethodImpl(Inline)]
        public void CopyTo(Span<T> dst, uint offset)
            => api.copy(Storage, offset, dst);
    }
}