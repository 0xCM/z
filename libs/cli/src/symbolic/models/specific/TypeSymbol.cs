//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;
    using CA = Microsoft.CodeAnalysis;

    public readonly struct TypeSymbol : ICaSymbol<TypeSymbol,ITypeSymbol>
    {
        public ITypeSymbol Source {get;}

        [MethodImpl(Inline)]
        public TypeSymbol(ITypeSymbol src)
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


        public CA.TypeKind TypeKind
            => Source.TypeKind;

        public INamedTypeSymbol BaseType
            => Source.BaseType;

        public ReadOnlySpan<NamedTypeSymbol> Interfaces
        {
            [MethodImpl(Inline)]
            get => api.materialize(Source.Interfaces.AsSpan(), default(NamedTypeSymbol));
        }

        public ReadOnlySpan<NamedTypeSymbol> AllInterfaces
        {
            [MethodImpl(Inline)]
            get => api.materialize(Source.AllInterfaces.AsSpan(), default(NamedTypeSymbol));
        }

        public bool IsReferenceType
            => Source.IsReferenceType;

        public bool IsValueType
            => Source.IsValueType;

        public bool IsAnonymousType
            => Source.IsAnonymousType;

        public bool IsTupleType
            => Source.IsTupleType;

        public bool IsNativeIntegerType
            => Source.IsNativeIntegerType;

        public ITypeSymbol OriginalDefinition
            => Source.OriginalDefinition;

        public SpecialType SpecialType
            => Source.SpecialType;

        public bool IsRefLikeType
            => Source.IsRefLikeType;

        public bool IsUnmanagedType
            => Source.IsUnmanagedType;

        public bool IsReadOnly
            => Source.IsReadOnly;

        public NullableAnnotation NullableAnnotation
            => Source.NullableAnnotation;

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

        public ISymbol ContainingSymbol
            => Source.ContainingSymbol;

        public IAssemblySymbol ContainingAssembly
            => Source.ContainingAssembly;

        public IModuleSymbol ContainingModule
            => Source.ContainingModule;

        public INamedTypeSymbol ContainingType
            => Source.ContainingType;

        public INamespaceSymbol ContainingNamespace
            => Source.ContainingNamespace;

        public bool IsDefinition
            => Source.IsDefinition;

        public bool IsStatic
            => Source.IsStatic;

        public bool IsVirtual
            => Source.IsVirtual;

        public bool IsOverride
            => Source.IsOverride;

        public bool IsAbstract
            => Source.IsAbstract;

        public bool IsSealed => Source.IsSealed;

        public bool IsExtern => Source.IsExtern;

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

        public bool HasUnsupportedMetadata
            => Source.HasUnsupportedMetadata;

        public ISymbol FindImplementationForInterfaceMember(ISymbol interfaceMember)
            => Source.FindImplementationForInterfaceMember(interfaceMember);

        public string ToDisplayString(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
        {
            return Source.ToDisplayString(topLevelNullability, format);
        }

        public ImmutableArray<SymbolDisplayPart> ToDisplayParts(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
        {
            return Source.ToDisplayParts(topLevelNullability, format);
        }

        public string ToMinimalDisplayString(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayString(semanticModel, topLevelNullability, position, format);

        public ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayParts(semanticModel, topLevelNullability, position, format);

        public ITypeSymbol WithNullableAnnotation(NullableAnnotation nullableAnnotation)
            => Source.WithNullableAnnotation(nullableAnnotation);

        public ReadOnlySpan<CaSymbol> GetMembers()
            => api.materialize(Source.GetMembers().AsSpan());

        public ImmutableArray<ISymbol> GetMembers(string name)
            => Source.GetMembers(name);

        public ReadOnlySpan<NamedTypeSymbol> GetTypeMembers()
            => api.materialize(Source.GetTypeMembers().AsSpan(), default(NamedTypeSymbol));

        public ReadOnlySpan<NamedTypeSymbol> GetTypeMembers(string name)
            => api.materialize(Source.GetTypeMembers(name).AsSpan(), default(NamedTypeSymbol));

        public ReadOnlySpan<NamedTypeSymbol> GetTypeMembers(string name, int arity)
            => api.materialize(Source.GetTypeMembers(name, arity).AsSpan(), default(NamedTypeSymbol));

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

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public bool Equals(TypeSymbol src)
            => Source.Equals(src.Source);

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator TypeSymbol(CaSymbol<ITypeSymbol> src)
            => new TypeSymbol(src.Source);
    }
}