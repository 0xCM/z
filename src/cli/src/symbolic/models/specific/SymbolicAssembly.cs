//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public readonly struct SymbolicAssembly : ICaSymbolArtifact<ClrAssembly,AssemblySymbol>
    {
        public ClrAssembly Artifact {get;}

        public AssemblySymbol Symbol {get;}

        [MethodImpl(Inline)]
        public SymbolicAssembly(ClrAssembly a, AssemblySymbol s)
        {
            Artifact = a;
            Symbol = s;
        }

        [MethodImpl(Inline)]
        public static implicit operator SymbolicAssembly((Assembly a, AssemblySymbol s) src)
            => new SymbolicAssembly(src.a, src.s);
    }    
}