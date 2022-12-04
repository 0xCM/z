//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    using static sys;

    public partial class api
    {        
        public static ReadOnlySeq<TypeDef> typedefs(params Assembly[] src)
            => from type in src.Types().Tagged<TypeDefAttribute>().Concrete()
               let tag = type.Tag<TypeDefAttribute>().Require()
               select new TypeDef {
                    Scope = tag.Scope,
                    Name = text.ifempty(tag.TypeName, type.Name)
                    };

    }
}
