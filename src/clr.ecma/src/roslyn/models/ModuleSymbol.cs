//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct ModuleSymbol : ICaSymbol<ModuleSymbol,IModuleSymbol>
    {
        public IModuleSymbol Source {get;}

        [MethodImpl(Inline)]
        public ModuleSymbol(IModuleSymbol src)
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

        public NamespaceSymbol GlobalNamespace
            => api.from(Source.GlobalNamespace);

        public ImmutableArray<AssemblyIdentity> ReferencedAssemblies
            => Source.ReferencedAssemblies;

        public ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols
            => Source.ReferencedAssemblySymbols;

        public SymbolKind Kind
            => Source.Kind;

        public string Language
            => Source.Language;

        public string Name
            => Source.Name;

        public string MetadataName
            => Source.MetadataName;

        public ISymbol ContainingSymbol
            => Source.ContainingSymbol;

        public IAssemblySymbol ContainingAssembly
            => Source.ContainingAssembly;

        IModuleSymbol ContainingModule
            => Source.ContainingModule;

        INamedTypeSymbol ContainingType
            => Source.ContainingType;

        INamespaceSymbol ContainingNamespace
            => Source.ContainingNamespace;

        bool IsDefinition
            => Source.IsDefinition;

        bool IsStatic
            => Source.IsStatic;

        bool IsVirtual
            => Source.IsVirtual;

        bool IsOverride
            => Source.IsOverride;

        bool IsAbstract
            => Source.IsAbstract;

        bool IsSealed
            => Source.IsSealed;

        bool IsExtern
            => Source.IsExtern;

        public bool IsImplicitlyDeclared
            => Source.IsImplicitlyDeclared;

        public bool CanBeReferencedByName
            => Source.CanBeReferencedByName;

        public ImmutableArray<Location> Locations
            => Source.Locations;

        public ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
            => Source.DeclaringSyntaxReferences;

        public Accessibility DeclaredAccessibility
            => Source.DeclaredAccessibility;

        public ISymbol OriginalDefinition
            => Source.OriginalDefinition;

        public bool HasUnsupportedMetadata
            => Source.HasUnsupportedMetadata;

        public INamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
            => Source.GetModuleNamespace(namespaceSymbol);

        public ModuleMetadata GetMetadata()
            => Source.GetMetadata();

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

        public bool Equals(ModuleSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator ModuleSymbol(CaSymbol<IModuleSymbol> src)
            => new ModuleSymbol(src.Source);
    }

}