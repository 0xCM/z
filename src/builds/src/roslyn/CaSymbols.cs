//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Roslyn;
    
    using static sys;

    [ApiHost]
    public readonly struct CaSymbols
    {
        public static string format<T>(T src)
            where T : ICaSymbol
                => src.Source?.ToDisplayString() ?? "<null>";

        [MethodImpl(Inline)]
        public static CaSymbolKey<T> symkey<T>(T symbol, ulong key)
            where T : ICaSymbol
                => (symbol,key);

        [MethodImpl(Inline), Op]
        public static CaSymbolSet set(params MetadataReference[] metadata)
            => new CaSymbolSet(metadata);

        [Op]
        public static CaSymbolLookup lookup(CaSymbolKey[] src)
            => new CaSymbolLookup(src);

        [MethodImpl(Inline), Op]
        public static CaSymbol from(ISymbol src)
            => new CaSymbol(src);

        [MethodImpl(Inline), Op]
        public static AssemblySymbol from(IAssemblySymbol src)
            => new AssemblySymbol(src);

        [MethodImpl(Inline), Op]
        public static ModuleSymbol from(IModuleSymbol src)
            => new ModuleSymbol(src);

        [MethodImpl(Inline), Op]
        public static NamespaceSymbol from(INamespaceSymbol src)
            => new NamespaceSymbol(src);

        [MethodImpl(Inline), Op]
        public static NamedTypeSymbol from(INamedTypeSymbol src)
            => new NamedTypeSymbol(src);

        [MethodImpl(Inline), Op]
        public static TypeSymbol from(ITypeSymbol src)
            => new TypeSymbol(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> convert<T>(ReadOnlySpan<CaSymbol> src)
            where T : ICaSymbol
                => recover<CaSymbol,T>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> materialize<S,T>(ReadOnlySpan<S> src, T target = default)
            where S : ISymbol
            where T : ICaSymbol
                => recover<S,T>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<CaSymbol> materialize<S>(ReadOnlySpan<S> src)
            where S : ISymbol
                => recover<S,CaSymbol>(src);

        [MethodImpl(Inline)]
        public static Roslyn.Symbols<T> index<T>(T[] src)
            where T : ISymbol
                => src;

        [MethodImpl(Inline)]
        public static CaSymbol<T> define<T>(T src)
            where T : ISymbol
                => new CaSymbol<T>(src);
   }
}