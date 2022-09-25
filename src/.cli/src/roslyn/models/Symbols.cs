//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static core;

    public sealed class Symbols : CaSymbols<Symbols,ISymbol>, ICaSymbols<ISymbol>
    {
        public Symbols()
        {

        }

        public Symbols(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public Symbols(ISymbol[] src)
        {
            Data = src;
        }

        public new Span<CaSymbol> Edit
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CaSymbol>(base.Edit);
        }

        public new ReadOnlySpan<CaSymbol> View
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CaSymbol>(base.View);
        }

        public ref CaSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator Symbols(ISymbol[] src)
            => new Symbols(src);
    }
}