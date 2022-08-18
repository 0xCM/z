//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeAlias : ITypeAlias
    {
        public IType Type {get;}

        public Identifier Alias {get;}

        [MethodImpl(Inline)]
        public TypeAlias(IType type, Identifier alias)
        {
            Type = type;
            Alias = alias;
        }
    }
}