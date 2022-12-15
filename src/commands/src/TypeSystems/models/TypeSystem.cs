//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public record class TypeSystem
    {
        public @string Name;

        public ReadOnlySeq<TypeDef> TypeDefs;
    }
}