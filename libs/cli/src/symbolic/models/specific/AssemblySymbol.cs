//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using System.Linq;

    using static core;

    using api = CaSymbols;

    public readonly struct AssemblySymbol : ICaSymbol<AssemblySymbol,IAssemblySymbol>
    {
        public IAssemblySymbol Source {get;}

        [MethodImpl(Inline)]
        public AssemblySymbol(IAssemblySymbol src)
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

        public bool IsInteractive
            => Source.IsInteractive;

        public AssemblyIdentity Identity
            => Source.Identity;

        public NamespaceSymbol GlobalNamespace
        {
            [MethodImpl(Inline)]
            get => new NamespaceSymbol(Source.GlobalNamespace);
        }

        public ReadOnlySpan<ModuleSymbol> Modules
        {
            [MethodImpl(Inline)]
            get => api.materialize(Source.Modules.ToReadOnlySpan(), default(ModuleSymbol));
        }

        public ICollection<string> TypeNames
            => Source.TypeNames;

        public ICollection<string> NamespaceNames
            => Source.NamespaceNames;

        public bool MightContainExtensionMethods
            => Source.MightContainExtensionMethods;

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

        public bool IsSealed
            => Source.IsSealed;

        public bool IsExtern
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

        public bool GivesAccessTo(IAssemblySymbol toAssembly)
            => Source.GivesAccessTo(toAssembly);

        public INamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
            => Source.GetTypeByMetadataName(fullyQualifiedMetadataName);

        public INamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
            => Source.ResolveForwardedType(fullyQualifiedMetadataName);

        public ReadOnlySpan<INamedTypeSymbol> GetForwardedTypes()
            => Source.GetForwardedTypes().AsSpan();

        public AssemblyMetadata GetMetadata()
            => Source.GetMetadata();

        public ReadOnlySpan<ModuleMetadata> GetModuleMetadata()
            => GetMetadata().GetModules().AsSpan();

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

        public bool Equals(AssemblySymbol src)
            => Source.Equals(src.Source);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public ReadOnlySpan<FilePath> GetReferencePaths(FolderPath root)
        {
            var refs = GetReferences();
            var count = refs.Length;
            var buffer = span<FilePath>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                if(Resolve(skip(refs,i), root, out var path))
                    seek(buffer,counter++) = path;
            }
            return slice(buffer,0,counter);
        }

        public bool Resolve(AssemblyIdentity src, FolderPath root, out FilePath dst)
        {
            dst = root + FS.file(src.Name, FS.Dll);
            return dst.Exists;
        }


        public ReadOnlySpan<AssemblyIdentity> GetReferences()
            => Source.Modules
                .SelectMany(m => m.ReferencedAssemblies)
                .Distinct()
                .Array();

        public @string DocXml()
            => GetDocumentationCommentXml();

        [MethodImpl(Inline)]
        public static implicit operator AssemblySymbol(CaSymbol<IAssemblySymbol> src)
            => new AssemblySymbol(src.Source);
    }    
}