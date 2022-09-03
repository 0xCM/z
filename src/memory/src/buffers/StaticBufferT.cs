//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = StaticBuffers;
    using static core;

    /// <summary>
    /// Supertype for covers with locations that will be pinned for the domain lifetime
    /// </summary>
    /// <typeparam name="T">The covered content type</typeparam>
    public abstract class StaticBuffer<T> : IStaticBuffer<T>
    {
        /// <summary>
        /// The number of covered cells
        /// </summary>
        public abstract uint CellCount {get;}

        /// <summary>
        /// Specifies the address of the buffer, not its content
        /// </summary>
        public MemoryAddress Address {get; protected set;}

        public Span<T> Content
        {
            [MethodImpl(Inline)]
            get => api.covered(this);
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Content,index);
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Content,index);
        }

        [MethodImpl(Inline)]
        public void Enumerate(uint i0, uint i1, Action<T> receiver)
            => api.enumerate(this, i0, i1, receiver);

        [MethodImpl(Inline)]
        public void Enumerate(Action<T> receiver)
            => api.enumerate(this, receiver);

        [MethodImpl(Inline)]
        protected virtual void Fill(Span<T> dst)
        {
            var src = Content;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
        }
    }
}