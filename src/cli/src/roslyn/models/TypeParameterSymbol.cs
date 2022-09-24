//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;
    using CA = Microsoft.CodeAnalysis;

    public readonly struct TypeParameterSymbol : ICaSymbol<TypeParameterSymbol,ITypeParameterSymbol>
    {
        public ITypeParameterSymbol Source {get;}

        [MethodImpl(Inline)]
        public TypeParameterSymbol(ITypeParameterSymbol src)
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

        public int Ordinal => Source.Ordinal;

        public VarianceKind Variance => Source.Variance;

        public TypeParameterKind TypeParameterKind => Source.TypeParameterKind;

        public IMethodSymbol DeclaringMethod => Source.DeclaringMethod;

        public INamedTypeSymbol DeclaringType => Source.DeclaringType;

        public bool HasReferenceTypeConstraint => Source.HasReferenceTypeConstraint;

        public NullableAnnotation ReferenceTypeConstraintNullableAnnotation => Source.ReferenceTypeConstraintNullableAnnotation;

        public bool HasValueTypeConstraint => Source.HasValueTypeConstraint;

        public bool HasUnmanagedTypeConstraint => Source.HasUnmanagedTypeConstraint;

        public bool HasNotNullConstraint => Source.HasNotNullConstraint;

        public bool HasConstructorConstraint => Source.HasConstructorConstraint;

        public ImmutableArray<ITypeSymbol> ConstraintTypes => Source.ConstraintTypes;

        public ImmutableArray<NullableAnnotation> ConstraintNullableAnnotations => Source.ConstraintNullableAnnotations;

        public ITypeParameterSymbol OriginalDefinition => Source.OriginalDefinition;

        public ITypeParameterSymbol ReducedFrom => Source.ReducedFrom;

        public CA.TypeKind TypeKind => Source.TypeKind;

        public INamedTypeSymbol BaseType => Source.BaseType;

        public ImmutableArray<INamedTypeSymbol> Interfaces => Source.Interfaces;

        public ImmutableArray<INamedTypeSymbol> AllInterfaces => Source.AllInterfaces;

        public bool IsReferenceType => Source.IsReferenceType;

        public bool IsValueType => Source.IsValueType;

        public bool IsAnonymousType => Source.IsAnonymousType;

        public bool IsTupleType => Source.IsTupleType;

        public bool IsNativeIntegerType => Source.IsNativeIntegerType;

        public SpecialType SpecialType => Source.SpecialType;

        public bool IsRefLikeType => Source.IsRefLikeType;

        public bool IsUnmanagedType => Source.IsUnmanagedType;

        public bool IsReadOnly => Source.IsReadOnly;

        public NullableAnnotation NullableAnnotation => Source.NullableAnnotation;

        public bool IsNamespace => Source.IsNamespace;

        public bool IsType => Source.IsType;

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

        public bool HasUnsupportedMetadata => Source.HasUnsupportedMetadata;


        public ISymbol FindImplementationForInterfaceMember(ISymbol interfaceMember)
        {
            return Source.FindImplementationForInterfaceMember(interfaceMember);
        }

        public string ToDisplayString(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
        {
            return Source.ToDisplayString(topLevelNullability, format);
        }

        public ImmutableArray<SymbolDisplayPart> ToDisplayParts(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
        {
            return Source.ToDisplayParts(topLevelNullability, format);
        }

        public string ToMinimalDisplayString(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
        {
            return Source.ToMinimalDisplayString(semanticModel, topLevelNullability, position, format);
        }

        public ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
        {
            return Source.ToMinimalDisplayParts(semanticModel, topLevelNullability, position, format);
        }

        public ITypeSymbol WithNullableAnnotation(NullableAnnotation nullableAnnotation)
        {
            return Source.WithNullableAnnotation(nullableAnnotation);
        }

        public ImmutableArray<ISymbol> GetMembers()
        {
            return Source.GetMembers();
        }

        public ImmutableArray<ISymbol> GetMembers(string name)
        {
            return Source.GetMembers(name);
        }

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers()
        {
            return Source.GetTypeMembers();
        }

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers(string name)
        {
            return Source.GetTypeMembers(name);
        }

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers(string name, int arity)
        {
            return Source.GetTypeMembers(name, arity);
        }

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

        public bool Equals(TypeParameterSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator TypeParameterSymbol(CaSymbol<ITypeParameterSymbol> src)
            => new TypeParameterSymbol(src.Source);
    }
}