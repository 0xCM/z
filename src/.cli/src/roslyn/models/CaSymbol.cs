//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct CaSymbol : ICaSymbol
    {
        public ISymbol Source {get;}

        [MethodImpl(Inline)]
        public CaSymbol(ISymbol src)
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

        /// <inheritdoc cref='ISymbol.Kind'/>
        public SymbolKind Kind
        {
            [MethodImpl(Inline)]
            get => Source.Kind;
        }

        /// <inheritdoc cref='ISymbol.Language'/>
        public string Language
        {
            [MethodImpl(Inline)]
            get => Source.Language;
        }

        /// <inheritdoc cref='ISymbol.Name'/>
        public string Name
        {
            [MethodImpl(Inline)]
            get => Source.Name;
        }

        /// <inheritdoc cref='ISymbol.MetadataName'/>
        public string MetadataName
        {
            [MethodImpl(Inline)]
            get => Source.MetadataName;
        }

        /// <inheritdoc cref='ISymbol.ContainingSymbol'/>
        public CaSymbol ContainingSymbol
        {
            [MethodImpl(Inline)]
            get => new CaSymbol(Source.ContainingSymbol);
        }

        /// <inheritdoc cref='ISymbol.ContainingAssembly'/>
        public IAssemblySymbol ContainingAssembly
        {
            [MethodImpl(Inline)]
            get => Source.ContainingAssembly;
        }

        /// <inheritdoc cref='ISymbol.ContainingModule'/>
        public IModuleSymbol ContainingModule
        {
            [MethodImpl(Inline)]
            get => Source.ContainingModule;
        }

        /// <inheritdoc cref='ISymbol.ContainingType'/>
        public INamedTypeSymbol ContainingType
        {
            [MethodImpl(Inline)]
            get => Source.ContainingType;
        }

        /// <inheritdoc cref='ISymbol.ContainingNamespace'/>
        public INamespaceSymbol ContainingNamespace
        {
            [MethodImpl(Inline)]
            get => Source.ContainingNamespace;
        }

        /// <inheritdoc cref='ISymbol.IsDefinition'/>
        public bool IsDefinition
        {
            [MethodImpl(Inline)]
            get => Source.IsDefinition;
        }

        /// <inheritdoc cref='ISymbol.IsStatic'/>
        public bool IsStatic
        {
            [MethodImpl(Inline)]
            get => Source.IsStatic;
        }

        /// <inheritdoc cref='ISymbol.IsVirtual'/>
        public bool IsVirtual
        {
            [MethodImpl(Inline)]
            get => Source.IsVirtual;
        }

        /// <inheritdoc cref='ISymbol.IsOverride'/>
        public bool IsOverride
        {
            [MethodImpl(Inline)]
            get => Source.IsOverride;
        }

        /// <inheritdoc cref='ISymbol.IsAbstract'/>
        public bool IsAbstract
        {
            [MethodImpl(Inline)]
            get => Source.IsAbstract;
        }

        /// <inheritdoc cref='ISymbol.IsSealed'/>
        public bool IsSealed
        {
            [MethodImpl(Inline)]
            get => Source.IsSealed;
        }

        /// <inheritdoc cref='ISymbol.IsExtern'/>
        public bool IsExtern
        {
            [MethodImpl(Inline)]
            get => Source.IsExtern;
        }

        /// <inheritdoc cref='ISymbol.IsImplicitlyDeclared'/>
        public bool IsImplicitlyDeclared
        {
            [MethodImpl(Inline)]
            get => Source.IsImplicitlyDeclared;
        }

        /// <inheritdoc cref='ISymbol.CanBeReferencedByName'/>
        public bool CanBeReferencedByName
        {
            [MethodImpl(Inline)]
            get => Source.CanBeReferencedByName;
        }

        /// <inheritdoc cref='ISymbol.Locations'/>
        public ReadOnlySpan<Location> Locations
        {
            [MethodImpl(Inline)]
            get => Source.Locations.AsSpan();
        }

        /// <inheritdoc cref='ISymbol.ContainingModule'/>
        public ReadOnlySpan<SyntaxReference> DeclaringSyntaxReferences
        {
            [MethodImpl(Inline)]
            get => Source.DeclaringSyntaxReferences.AsSpan();
        }

        public Accessibility DeclaredAccessibility
        {
            [MethodImpl(Inline)]
            get => Source.DeclaredAccessibility;
        }

        public ISymbol OriginalDefinition
        {
            [MethodImpl(Inline)]
            get => Source.OriginalDefinition;
        }

        public bool HasUnsupportedMetadata
        {
            [MethodImpl(Inline)]
            get => Source.HasUnsupportedMetadata;
        }

        [MethodImpl(Inline)]
        public ImmutableArray<AttributeData> GetAttributes()
            => Source.GetAttributes();

        [MethodImpl(Inline)]
        public void Accept(SymbolVisitor visitor)
            => Source.Accept(visitor);

        [MethodImpl(Inline)]
        public TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
            => Source.Accept(visitor);

        [MethodImpl(Inline)]
        public string GetDocumentationCommentId()
            => Source.GetDocumentationCommentId();

        [MethodImpl(Inline)]
        public string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default)
            => Source.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);

        [MethodImpl(Inline)]
        public string ToDisplayString(SymbolDisplayFormat format = null)
            => Source.ToDisplayString(format);

        [MethodImpl(Inline)]
        public ImmutableArray<SymbolDisplayPart> ToDisplayParts(SymbolDisplayFormat format = null)
            => Source.ToDisplayParts(format);

        [MethodImpl(Inline)]
        public string ToMinimalDisplayString(SemanticModel semanticModel, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayString(semanticModel, position, format);

        [MethodImpl(Inline)]
        public ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(SemanticModel semanticModel, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayParts(semanticModel, position, format);

        [MethodImpl(Inline)]
        public bool Equals(CaSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        public static CaSymbol Empty
        {
            [MethodImpl(Inline)]
            get => new CaSymbol(null);
        }
    }

}