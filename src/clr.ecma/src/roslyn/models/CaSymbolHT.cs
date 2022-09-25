//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct CaSymbol<H,T> : ICaSymbol<H,T>
        where T : ISymbol
        where H : new()
    {
        readonly CaSymbols<H,T> _Source;

        readonly uint Index;

        [MethodImpl(Inline)]
        internal CaSymbol(CaSymbols<H,T> src, uint index)
        {
            _Source  = src;
            Index = index;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source != null;
        }

        public T Source
        {
            [MethodImpl(Inline)]
            get => _Source.Subject(Index);
        }

        public SymbolKind Kind => Source.Kind;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        ISymbol ICaSymbol.Source
            => Source;

        public string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default)
            => Source.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator CaSymbol<T>(CaSymbol<H,T> src)
            => new CaSymbol<T>(src.Source);
    }
}