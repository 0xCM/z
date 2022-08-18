//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    using static CaSymbolModels;

    public ref struct CaSymbolSet
    {
        public CaSymbolSet(params MetadataReference[] metadata)
            : this()
        {
            Metadata = metadata;
            Assemblies = default;
            Types = default;
            Methods = default;
            Fields = default;
        }

        public readonly ReadOnlySpan<MetadataReference> Metadata;

        public ReadOnlySpan<AssemblySymbol> Assemblies;

        public ReadOnlySpan<TypeSymbol> Types;

        public ReadOnlySpan<MethodSymbol> Methods;

        public ReadOnlySpan<FieldSymbol> Fields;

        public static CaSymbolSet Empty => default;
    }
}