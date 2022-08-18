//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using api = CaSymbols;

    public readonly struct FieldSymbol : ICaSymbol<FieldSymbol,IFieldSymbol>
    {
        public IFieldSymbol Source {get;}

        [MethodImpl(Inline)]
        public FieldSymbol(IFieldSymbol src)
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

        public ISymbol AssociatedSymbol
            => Source.AssociatedSymbol;

        public bool IsConst => Source.IsConst;

        public bool IsReadOnly => Source.IsReadOnly;

        public bool IsVolatile => Source.IsVolatile;

        public bool IsFixedSizeBuffer => Source.IsFixedSizeBuffer;

        public ITypeSymbol Type => Source.Type;

        public NullableAnnotation NullableAnnotation => Source.NullableAnnotation;

        public bool HasConstantValue => Source.HasConstantValue;

        public object ConstantValue => Source.ConstantValue;

        public ImmutableArray<CustomModifier> CustomModifiers => Source.CustomModifiers;

        public IFieldSymbol OriginalDefinition => Source.OriginalDefinition;

        public IFieldSymbol CorrespondingTupleField => Source.CorrespondingTupleField;

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

        public bool Equals(FieldSymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public @string DocXml()
            => GetDocumentationCommentXml();

        public static implicit operator FieldSymbol(CaSymbol<IFieldSymbol> src)
            => new FieldSymbol(src.Source);
    }
}