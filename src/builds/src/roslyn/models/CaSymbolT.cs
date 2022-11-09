//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct CaSymbol<T> : ICaSymbol<T>
        where T : ISymbol
    {
        public readonly T Source {get;}

        [MethodImpl(Inline)]
        public CaSymbol(T src)
        {
            Source = src;
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

        public ISymbol Untyped
        {
            [MethodImpl(Inline)]
            get => Source;
        }

        public SymbolKind Kind
        {
            [MethodImpl(Inline)]
            get => Untyped.Kind;
        }

        public string Language
        {
            [MethodImpl(Inline)]
            get => Untyped.Language;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Untyped.Name;
        }

        public string MetadataName
        {
            [MethodImpl(Inline)]
            get => Untyped.MetadataName;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default)
            => Source.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator CaSymbol(CaSymbol<T> src)
            => new CaSymbol(src.Untyped);
    }
}