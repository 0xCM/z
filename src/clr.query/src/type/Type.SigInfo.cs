//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        [Op]
        public static ClrTypeSigInfo SigInfo(this Type type)
            => ClrMethodArtifact.siginfo(type);
    }
}