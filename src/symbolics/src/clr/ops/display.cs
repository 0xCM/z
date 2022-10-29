//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [Op]
        public static MethodDisplaySig display(in ClrMethodArtifact src)
            => new MethodDisplaySig(ClrMethodArtifact.format(src));
    }
}