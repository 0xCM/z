//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static core;
    using static CaSymbolModels;

    using api = CaSymbols;

    public readonly struct NamespaceSymbol : ICaSymbol<NamespaceSymbol,INamespaceSymbol>
    {
        public INamespaceSymbol Source {get;}

        [MethodImpl(Inline)]
        public NamespaceSymbol(INamespaceSymbol src)
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

        public ReadOnlySpan<TypeSymbol> GetTypes()
        {
            var dst = list<TypeSymbol>();
            Drill(Source, dst);
            return dst.ViewDeposited();
        }

        public bool IsGlobalNamespace
            => Source.IsGlobalNamespace;

        public NamespaceKind NamespaceKind
            => Source.NamespaceKind;

        public CaCompilation<Compilation> ContainingCompilation
            => Source.ContainingCompilation;

        ReadOnlySpan<INamespaceSymbol> _ConstituentNamespaces
            => Source.ConstituentNamespaces.AsSpan();

        public ReadOnlySpan<NamespaceSymbol> ConstituentNamespaces
        {
            [MethodImpl(Inline)]
            get => recover<INamespaceSymbol,NamespaceSymbol>(_ConstituentNamespaces);
        }

        public bool IsNamespace
            => Source.IsNamespace;

        public bool IsType
            => Source.IsType;

        public SymbolKind Kind
            => Source.Kind;

        public string Language
            => Source.Language;

        public string Name
            => Source.Name;

        public string MetadataName
            => Source.MetadataName;

        public CaSymbol ContainingSymbol
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ContainingSymbol);
        }

        public AssemblySymbol ContainingAssembly
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ContainingAssembly);
        }

        public ModuleSymbol ContainingModule
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ContainingModule);
        }

        public NamedTypeSymbol ContainingType
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ContainingType);
        }

        public NamespaceSymbol ContainingNamespace
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ContainingNamespace);
        }

        public bool IsDefinition
        {
            [MethodImpl(Inline)]
            get => Source.IsDefinition;
        }

        bool IsStatic
        {
            [MethodImpl(Inline)]
            get => Source.IsStatic;
        }

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

        public ReadOnlySpan<Location> Locations
            => Source.Locations.AsSpan();

        public ReadOnlySpan<SyntaxReference> DeclaringSyntaxReferences
            => Source.DeclaringSyntaxReferences.AsSpan();

        public Accessibility DeclaredAccessibility
            => Source.DeclaredAccessibility;

        public ISymbol OriginalDefinition
            => Source.OriginalDefinition;

        public bool HasUnsupportedMetadata
            => Source.HasUnsupportedMetadata;

        public IEnumerable<INamespaceOrTypeSymbol> GetMembers()
            => Source.GetMembers();

        public IEnumerable<INamespaceOrTypeSymbol> GetMembers(string name)
            => Source.GetMembers(name);

        public IEnumerable<INamespaceSymbol> GetNamespaceMembers()
            => Source.GetNamespaceMembers();

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers()
            => Source.GetTypeMembers();

        public ReadOnlySpan<INamedTypeSymbol> GetTypeMembers(string name)
            => Source.GetTypeMembers(name).AsSpan();

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers(string name, int arity)
            => Source.GetTypeMembers(name, arity);

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

        public bool Equals(NamespaceSymbol src)
            => Source.Equals(src.Source);

        public override string ToString()
            => ToDisplayString();

        static void Drill(INamespaceSymbol src, List<TypeSymbol> dst)
        {
            foreach (var member in src.GetNamespaceMembers())
                Drill(member, dst);

            foreach (var member in src.GetTypeMembers())
            {
                if(member.CanBeReferencedByName)
                    dst.Add(new TypeSymbol(member));
            }
        }

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator NamespaceSymbol(CaSymbol<INamespaceSymbol> src)
            => new NamespaceSymbol(src.Source);
    }
}