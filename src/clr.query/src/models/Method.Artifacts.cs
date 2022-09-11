//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Derives a signature from reflected method metadata
        /// </summary>
        /// <param name="src">The source method</param>
        [Op]
        public static ClrMethodArtifact Artifact(this MethodInfo src)
            => ClrMethodArtifact.from(src);
    }
}