//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static core;

    public sealed class Symbols<T> : CaSymbols<Symbols<T>,T>, ICaSymbols<T>
        where T : ISymbol
    {
        public Symbols()
        {

        }

        public Symbols(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public Symbols(T[] src)
        {
            Data = src;
        }

        public ref CaSymbol<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        public new Span<CaSymbol<T>> Edit
        {
            [MethodImpl(Inline)]
            get => recover<T,CaSymbol<T>>(base.Edit);
        }

        public new ReadOnlySpan<CaSymbol<T>> View
        {
            [MethodImpl(Inline)]
            get => recover<T,CaSymbol<T>>(base.View);
        }

        [MethodImpl(Inline)]
        public static implicit operator Symbols<T>(T[] src)
            => new Symbols<T>(src);
    }
}