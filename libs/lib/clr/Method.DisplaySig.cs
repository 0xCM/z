//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static MethodDisplaySig DisplaySig(this MethodInfo src)
            => src.Artifact().DisplaySig;
    }
}