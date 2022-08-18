//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using CA = Microsoft.CodeAnalysis;

    public readonly struct PointerTypeSymbol : ICaSymbol<PointerTypeSymbol,IPointerTypeSymbol>
    {
        public IPointerTypeSymbol Source {get;}

        [MethodImpl(Inline)]
        public PointerTypeSymbol(IPointerTypeSymbol src)
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

        public ITypeSymbol PointedAtType => Source.PointedAtType;

        public ImmutableArray<CustomModifier> CustomModifiers => Source.CustomModifiers;

        public CA.TypeKind TypeKind => Source.TypeKind;

        public INamedTypeSymbol BaseType => Source.BaseType;

        public ImmutableArray<INamedTypeSymbol> Interfaces => Source.Interfaces;

        public ImmutableArray<INamedTypeSymbol> AllInterfaces => Source.AllInterfaces;

        public bool IsReferenceType => Source.IsReferenceType;

        public bool IsValueType => Source.IsValueType;

        public bool IsAnonymousType => Source.IsAnonymousType;

        public bool IsTupleType => Source.IsTupleType;

        public bool IsNativeIntegerType => Source.IsNativeIntegerType;

        public ITypeSymbol OriginalDefinition => Source.OriginalDefinition;

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

        [MethodImpl(Inline)]
        public static implicit operator PointerTypeSymbol(CaSymbol<IPointerTypeSymbol> src)
            => new PointerTypeSymbol(src.Source);

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


        public bool Equals(PointerTypeSymbol src)
            => Source.Equals(src.Source);

        public @string DocXml()
            => GetDocumentationCommentXml();

        public override string ToString()
            => ToDisplayString();
    }
}