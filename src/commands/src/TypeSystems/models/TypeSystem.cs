//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public record class TypeSystem
    {
        public @string Name;

        public ReadOnlySeq<TypeDef> TypeDefs;
    }
}