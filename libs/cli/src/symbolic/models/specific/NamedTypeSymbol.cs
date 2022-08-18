//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;
    using CA = Microsoft.CodeAnalysis;

    public readonly struct NamedTypeSymbol : ICaSymbol<NamedTypeSymbol,INamedTypeSymbol>
    {
        public INamedTypeSymbol Source {get;}

        [MethodImpl(Inline)]
        public NamedTypeSymbol(INamedTypeSymbol src)
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

        public int Arity
        {
            [MethodImpl(Inline)]
            get => Source.Arity;
        }

        public bool IsGenericType
        {
            [MethodImpl(Inline)]
            get => Source.IsGenericType;
        }

        public bool IsUnboundGenericType
        {
            [MethodImpl(Inline)]
            get => Source.IsUnboundGenericType;
        }

        public bool IsScriptClass
            => Source.IsScriptClass;

        public bool IsImplicitClass => Source.IsImplicitClass;

        public bool IsComImport => Source.IsComImport;

        public IEnumerable<string> MemberNames
            => Source.MemberNames;

        public ImmutableArray<ITypeParameterSymbol> TypeParameters
            => Source.TypeParameters;

        public ImmutableArray<ITypeSymbol> TypeArguments
            => Source.TypeArguments;

        public ImmutableArray<NullableAnnotation> TypeArgumentNullableAnnotations
            => Source.TypeArgumentNullableAnnotations;

        public INamedTypeSymbol OriginalDefinition
            => Source.OriginalDefinition;

        public IMethodSymbol DelegateInvokeMethod
            => Source.DelegateInvokeMethod;

        public INamedTypeSymbol EnumUnderlyingType
            => Source.EnumUnderlyingType;

        public INamedTypeSymbol ConstructedFrom
            => Source.ConstructedFrom;

        public ImmutableArray<IMethodSymbol> InstanceConstructors
            => Source.InstanceConstructors;

        public ImmutableArray<IMethodSymbol> StaticConstructors
            => Source.StaticConstructors;

        public ImmutableArray<IMethodSymbol> Constructors
            => Source.Constructors;

        public ISymbol AssociatedSymbol
            => Source.AssociatedSymbol;

        public bool MightContainExtensionMethods
            => Source.MightContainExtensionMethods;

        public INamedTypeSymbol TupleUnderlyingType
            => Source.TupleUnderlyingType;

        public ImmutableArray<IFieldSymbol> TupleElements
            => Source.TupleElements;

        public bool IsSerializable => Source.IsSerializable;

        public INamedTypeSymbol NativeIntegerUnderlyingType
            => Source.NativeIntegerUnderlyingType;

        public CA.TypeKind TypeKind
            => Source.TypeKind;

        public INamedTypeSymbol BaseType
            => Source.BaseType;

        public ImmutableArray<INamedTypeSymbol> Interfaces
            => Source.Interfaces;

        public ImmutableArray<INamedTypeSymbol> AllInterfaces
            => Source.AllInterfaces;

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

        public bool IsNamespace => Source.IsNamespace;

        public bool IsType => Source.IsType;

        public SymbolKind Kind => Source.Kind;

        public string Language => Source.Language;

        public string Name => Source.Name;

        public string MetadataName => Source.MetadataName;

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

        public bool IsSealed
            => Source.IsSealed;

        public bool IsExtern
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

        public bool HasUnsupportedMetadata
            => Source.HasUnsupportedMetadata;

        public ImmutableArray<CustomModifier> GetTypeArgumentCustomModifiers(int ordinal)
            => Source.GetTypeArgumentCustomModifiers(ordinal);

        public INamedTypeSymbol Construct(params ITypeSymbol[] typeArguments)
        {
            return Source.Construct(typeArguments);
        }

        public INamedTypeSymbol Construct(ImmutableArray<ITypeSymbol> typeArguments, ImmutableArray<NullableAnnotation> typeArgumentNullableAnnotations)
        {
            return Source.Construct(typeArguments, typeArgumentNullableAnnotations);
        }

        public INamedTypeSymbol ConstructUnboundGenericType()
            => Source.ConstructUnboundGenericType();

        public ISymbol FindImplementationForInterfaceMember(ISymbol interfaceMember)
        {
            return Source.FindImplementationForInterfaceMember(interfaceMember);
        }

        public string ToDisplayString(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
            => Source.ToDisplayString(topLevelNullability, format);

        public ImmutableArray<SymbolDisplayPart> ToDisplayParts(NullableFlowState topLevelNullability, SymbolDisplayFormat format = null)
        {
            return Source.ToDisplayParts(topLevelNullability, format);
        }

        public string ToMinimalDisplayString(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
        {
            return Source.ToMinimalDisplayString(semanticModel, topLevelNullability, position, format);
        }

        public ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(SemanticModel semanticModel, NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format = null)
            => Source.ToMinimalDisplayParts(semanticModel, topLevelNullability, position, format);

        public ITypeSymbol WithNullableAnnotation(NullableAnnotation nullableAnnotation)
            => Source.WithNullableAnnotation(nullableAnnotation);

        public ReadOnlySpan<CaSymbol> GetMembers()
            => api.materialize(Source.GetMembers().AsSpan());

        public ReadOnlySpan<CaSymbol> GetMembers(string name)
            => api.materialize(Source.GetMembers(name).AsSpan());

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers()
            => Source.GetTypeMembers();

        public ImmutableArray<INamedTypeSymbol> GetTypeMembers(string name)
            => Source.GetTypeMembers(name);

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


        public bool Equals(NamedTypeSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator NamedTypeSymbol(CaSymbol<INamedTypeSymbol> src)
            => new NamedTypeSymbol(src.Source);
    }
}