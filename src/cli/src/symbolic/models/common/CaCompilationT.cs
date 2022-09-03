//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static Algs;
    using static CaSymbolModels;

    using api = CaSymbols;

    public readonly struct CaCompilation<T> : INullity
        where T : Compilation
    {
        public readonly T Source;

        [MethodImpl(Inline)]
        public CaCompilation(T src)
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

        public AssemblySymbol Assembly
        {
            [MethodImpl(Inline)]
            get => api.from(Source.Assembly);
        }

        public CompilationOptions Options
            => Source.Options;

        public Deferred<SyntaxTree> SyntaxTrees
            => defer(Source.SyntaxTrees);

        public ReadOnlySpan<MetadataReference> ExternalReferences
            => Source.ExternalReferences.AsSpan();

        public ReadOnlySpan<MetadataReference> DirectiveReferences
            => Source.DirectiveReferences.AsSpan();

        public Deferred<MetadataReference> References
            => defer(Source.References);

        public Deferred<AssemblyIdentity> ReferencedAssemblyNames
            => defer(Source.ReferencedAssemblyNames);

        public AssemblySymbol GetAssemblySymbol(MetadataReference src)
            => new AssemblySymbol((IAssemblySymbol)Source.GetAssemblyOrModuleSymbol(src));

        public MetadataReference GetMetadataReference(IAssemblySymbol src)
            => Source.GetMetadataReference(src);

        [MethodImpl(Inline)]
        public static implicit operator CaCompilation<T>(T src)
            => new CaCompilation<T>(src);
    }
}