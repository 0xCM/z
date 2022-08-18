//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static GenericState GenericPartition(this MethodInfo src)
            => src.IsNonGeneric() ? GenericStateKind.Nongeneric : GenericStateKind.OpenGeneric;

        [Op]
        public static bool IsMemberOf(this MethodInfo src, GenericState g)
            => src.GenericPartition().State == g.State;
    }
}