//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public readonly struct SymbolicType : ICaSymbolArtifact<ClrTypeAdapter,TypeSymbol>
    {
        public ClrTypeAdapter Artifact {get;}

        public TypeSymbol Symbol {get;}

        [MethodImpl(Inline)]
        public SymbolicType(ClrTypeAdapter src, TypeSymbol sym)
        {
            Artifact = src;
            Symbol = sym;
        }

        [MethodImpl(Inline)]
        public static implicit operator SymbolicType((Type a, TypeSymbol s) src)
            => new SymbolicType(src.a, src.s);
    }    
}