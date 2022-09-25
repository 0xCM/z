//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    /// <summary>
    /// Represents a using alias
    /// </summary>
    public readonly struct AliasSymbol : ICaSymbol<AliasSymbol,IAliasSymbol>
    {
        public IAliasSymbol Source {get;}

        [MethodImpl(Inline)]
        public AliasSymbol(IAliasSymbol src)
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

        public INamespaceOrTypeSymbol Target => Source.Target;

        public SymbolKind Kind => Source.Kind;

        public string Language => Source.Language;

        public string Name => Source.Name;

        public string MetadataName => Source.MetadataName;

        public ISymbol ContainingSymbol => Source.ContainingSymbol;

        public IAssemblySymbol ContainingAssembly => Source.ContainingAssembly;

        public IModuleSymbol ContainingModule => Source.ContainingModule;

        public INamedTypeSymbol ContainingType => Source.ContainingType;

        public INamespaceSymbol ContainingNamespace => Source.ContainingNamespace;

        public bool IsDefinition => Source.IsDefinition;

        public bool IsStatic => Source.IsStatic;

        public bool IsVirtual => Source.IsVirtual;

        public bool IsOverride => Source.IsOverride;

        public bool IsAbstract => Source.IsAbstract;

        public bool IsSealed => Source.IsSealed;

        public bool IsExtern => Source.IsExtern;

        public bool IsImplicitlyDeclared => Source.IsImplicitlyDeclared;

        public bool CanBeReferencedByName => Source.CanBeReferencedByName;

        public ImmutableArray<Location> Locations => Source.Locations;

        public ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => Source.DeclaringSyntaxReferences;

        public Accessibility DeclaredAccessibility => Source.DeclaredAccessibility;

        public ISymbol OriginalDefinition => Source.OriginalDefinition;

        public bool HasUnsupportedMetadata => Source.HasUnsupportedMetadata;

        public ReadOnlySpan<AttributeData> GetAttributes()
            => Source.GetAttributes().AsSpan();

        public void Accept(SymbolVisitor visitor)
            => Source.Accept(visitor);

        public TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
            => Source.Accept(visitor);

        public string GetDocumentationCommentId()
            => Source.GetDocumentationCommentId();

        public string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default)
            => Source.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);

        public string ToDisplayString(SymbolDisplayFormat format = null)
            => Source.ToDisplayString(format);

        public ReadOnlySpan<SymbolDisplayPart> ToDisplayParts(SymbolDisplayFormat format = null)
            => Source.ToDisplayParts(format).AsSpan();

        public string ToMinimalDisplayString(SemanticModel semanticModel, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayString(semanticModel, position, format);

        public ReadOnlySpan<SymbolDisplayPart> ToMinimalDisplayParts(SemanticModel semanticModel, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayParts(semanticModel, position, format).AsSpan();


        public bool Equals(AliasSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator AliasSymbol(CaSymbol<IAliasSymbol> src)
            => new AliasSymbol(src.Source);
    }
}