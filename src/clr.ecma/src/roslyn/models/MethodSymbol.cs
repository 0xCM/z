//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct MethodSymbol : ICaSymbol<MethodSymbol,IMethodSymbol>
    {
        public IMethodSymbol Source {get;}

        [MethodImpl(Inline)]
        public MethodSymbol(IMethodSymbol src)
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

        public ReadOnlySpan<Location> Locations
        {
            [MethodImpl(Inline)]
            get=> Source.Locations.AsSpan();
        }

        public MethodKind MethodKind
        {
            [MethodImpl(Inline)]
            get => Source.MethodKind;
        }

        public bool IsConstructor
        {
            [MethodImpl(Inline)]
            get => MethodKind == MethodKind.Constructor;
        }

        public bool IsPropertyGet
        {
            [MethodImpl(Inline)]
            get => MethodKind == MethodKind.PropertyGet;
        }

        public bool IsPropertySet
        {
            [MethodImpl(Inline)]
            get => MethodKind == MethodKind.PropertySet;
        }

        public bool IsOperator
        {
            [MethodImpl(Inline)]
            get => MethodKind == MethodKind.UserDefinedOperator || MethodKind == MethodKind.BuiltinOperator;
        }

        public bool IsIntrinsicOperator
        {
            [MethodImpl(Inline)]
            get => MethodKind == MethodKind.BuiltinOperator;
        }

        public bool IsLocalFunction
        {
            [MethodImpl(Inline)]
            get => Source.MethodKind == MethodKind.LocalFunction;
        }

        public int Arity
        {
            [MethodImpl(Inline)]
            get => Source.Arity;
        }

        public bool IsGenericMethod
        {
            [MethodImpl(Inline)]
            get => Source.IsGenericMethod;
        }

        public bool IsExtensionMethod
        {
            [MethodImpl(Inline)]
            get => Source.IsExtensionMethod;
        }

        public bool IsAsync
        {
            [MethodImpl(Inline)]
            get => Source.IsAsync;
        }

        public bool IsVararg
        {
            [MethodImpl(Inline)]
            get => Source.IsVararg;
        }

        public bool IsCheckedBuiltin
        {
            [MethodImpl(Inline)]
            get => Source.IsCheckedBuiltin;
        }

        public bool HidesBaseMethodsByName
        {
            [MethodImpl(Inline)]
            get => Source.HidesBaseMethodsByName;
        }

        public bool ReturnsVoid
        {
            [MethodImpl(Inline)]
            get => Source.ReturnsVoid;
        }

        public bool ReturnsByRef
        {
            [MethodImpl(Inline)]
            get => Source.ReturnsByRef;
        }

        public bool ReturnsByRefReadonly
        {
            [MethodImpl(Inline)]
            get => Source.ReturnsByRefReadonly;
        }

        public RefKind RefKind
        {
            [MethodImpl(Inline)]
            get => Source.RefKind;
        }

        public TypeSymbol ReturnType
        {
            [MethodImpl(Inline)]
            get => api.from(Source.ReturnType);
        }

        public NullableAnnotation ReturnNullableAnnotation
            => Source.ReturnNullableAnnotation;

        public ImmutableArray<ITypeSymbol> TypeArguments
        {
            get => Source.TypeArguments;
        }

        public ImmutableArray<NullableAnnotation> TypeArgumentNullableAnnotations
            => Source.TypeArgumentNullableAnnotations;

        public ImmutableArray<ITypeParameterSymbol> TypeParameters
            => Source.TypeParameters;

        public ImmutableArray<IParameterSymbol> Parameters
            => Source.Parameters;

        public IMethodSymbol ConstructedFrom
            => Source.ConstructedFrom;

        public bool IsReadOnly
        {
            [MethodImpl(Inline)]
            get => Source.IsReadOnly;
        }

        public bool IsInitOnly
            => Source.IsInitOnly;

        public IMethodSymbol OriginalDefinition
            => Source.OriginalDefinition;

        public IMethodSymbol OverriddenMethod
            => Source.OverriddenMethod;

        public ITypeSymbol ReceiverType
            => Source.ReceiverType;

        public NullableAnnotation ReceiverNullableAnnotation
            => Source.ReceiverNullableAnnotation;

        public IMethodSymbol ReducedFrom
            => Source.ReducedFrom;

        public ImmutableArray<IMethodSymbol> ExplicitInterfaceImplementations
            => Source.ExplicitInterfaceImplementations;

        public ImmutableArray<CustomModifier> ReturnTypeCustomModifiers
            => Source.ReturnTypeCustomModifiers;

        public ImmutableArray<CustomModifier> RefCustomModifiers
            => Source.RefCustomModifiers;

        public SignatureCallingConvention CallingConvention
            => Source.CallingConvention;

        public ImmutableArray<INamedTypeSymbol> UnmanagedCallingConventionTypes
            => Source.UnmanagedCallingConventionTypes;

        public ISymbol AssociatedSymbol
            => Source.AssociatedSymbol;

        public IMethodSymbol PartialDefinitionPart
            => Source.PartialDefinitionPart;

        public IMethodSymbol PartialImplementationPart
            => Source.PartialImplementationPart;

        public INamedTypeSymbol AssociatedAnonymousDelegate
            => Source.AssociatedAnonymousDelegate;

        public bool IsConditional
        {
            [MethodImpl(Inline)]
            get => Source.IsConditional;
        }

        public SymbolKind Kind
        {
            [MethodImpl(Inline)]
            get => Source.Kind;
        }

        public string Language
        {
            [MethodImpl(Inline)]
            get => Source.Language;
        }

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
        {
            [MethodImpl(Inline)]
            get => Source.IsDefinition;
        }

        public bool IsStatic
        {
            [MethodImpl(Inline)]
            get => Source.IsStatic;
        }

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

        public ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
            => Source.DeclaringSyntaxReferences;

        public Accessibility DeclaredAccessibility => Source.DeclaredAccessibility;

        public bool HasUnsupportedMetadata
            => Source.HasUnsupportedMetadata;

        public ITypeSymbol GetTypeInferredDuringReduction(ITypeParameterSymbol reducedFromTypeParameter)
            =>  Source.GetTypeInferredDuringReduction(reducedFromTypeParameter);

        public IMethodSymbol ReduceExtensionMethod(ITypeSymbol receiverType)
            => Source.ReduceExtensionMethod(receiverType);

        public ImmutableArray<AttributeData> GetReturnTypeAttributes()
            => Source.GetReturnTypeAttributes();

        public IMethodSymbol Construct(params ITypeSymbol[] typeArguments)
            => Source.Construct(typeArguments);

        public IMethodSymbol Construct(ImmutableArray<ITypeSymbol> typeArguments, ImmutableArray<NullableAnnotation> typeArgumentNullableAnnotations)
            => Source.Construct(typeArguments, typeArgumentNullableAnnotations);

        public DllImportData GetDllImportData()
            => Source.GetDllImportData();

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

        public bool Equals(MethodSymbol src)
            => Source.Equals(src.Source);

        public string Format()
        {
            var locations = Locations.Where(x => x.Kind != 0);
            var location = new object();
            if(locations.Length !=0)
                location = new FileUri(locations.First().GetLineSpan().Path);

            return string.Format("{0,-80} | {1} ", location, Source.ToDisplayString());
        }

        public override string ToString()
            => Format();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator MethodSymbol(CaSymbol<IMethodSymbol> src)
            => new MethodSymbol(src.Source);
    }   
}