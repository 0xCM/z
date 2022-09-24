//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static GenericState GenericState(this MethodInfo src)
            =>  src.IsClosedGeneric() ? GenericStateKind.ClosedGeneric
               : src.IsOpenGeneric() ? GenericStateKind.OpenGeneric
               : GenericStateKind.Nongeneric;
    }
}