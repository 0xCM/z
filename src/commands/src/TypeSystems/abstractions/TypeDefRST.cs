//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public abstract class TypeDef<R,S,T> : TypeDef<R,T> 
        where S : ITypeSystem, new()
        where R : TypeDef<R,S,T>, new()
    {
        public override @string Scope 
            => new S().Name;
    }
}