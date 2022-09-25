//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public readonly struct SymbolicMethod : ICaSymbolArtifact<ClrMethodAdapter,MethodSymbol>
    {
        public readonly ClrMethodAdapter Artifact;

        public readonly MethodSymbol Symbol;

        [MethodImpl(Inline)]
        public SymbolicMethod(ClrMethodAdapter src, MethodSymbol sym)
        {
            Artifact = src;
            Symbol = sym;
        }

        ClrMethodAdapter ICaSymbolArtifact<ClrMethodAdapter, MethodSymbol>.Artifact
            => Artifact;

        MethodSymbol ICaSymbolArtifact<ClrMethodAdapter, MethodSymbol>.Symbol
            => Symbol;

        [MethodImpl(Inline)]
        public static implicit operator SymbolicMethod((MethodInfo a, MethodSymbol s) src)
            => new SymbolicMethod(src.a, src.s);
    }
}