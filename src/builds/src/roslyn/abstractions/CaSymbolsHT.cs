//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static sys;

    public abstract class CaSymbols<H,T> : ICaSymbols<H,T>
        where T : ISymbol
        where H : new()
    {
        protected Index<T> Data;

        protected CaSymbols()
        {
            Data = sys.empty<T>();
        }

        protected CaSymbols(uint count)
        {
            Data = alloc<T>(count);
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        protected Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        protected ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        internal ref T Subject(uint index)
            => ref Data[index];

        [MethodImpl(Inline)]
        public CaSymbol<H,T> Symbol(uint index)
            => new CaSymbol<H,T>(this,index);

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public static H Empty
        {
            [MethodImpl(Inline)]
            get => new H();
        }
    }
}