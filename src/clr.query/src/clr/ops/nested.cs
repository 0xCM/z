//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static TypeAttributes;
    
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrTypeAdapter> nested(Type src)
            => recover<Type,ClrTypeAdapter>(src.GetNestedTypes());

        [MethodImpl(Inline), Op]
        public static bool nested(TypeAttributes src)
            => (src & (NestedPublic | NestedAssembly | NestedFamANDAssem | NestedFamily | NestedFamORAssem | NestedPrivate)) != 0;        
    }
}