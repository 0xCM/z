//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Defines a <see cref='ClrArtfactRef'/>
        /// </summary>
        /// <param name="token"></param>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        [MethodImpl(Inline), Op]
        public static EcmaArtifactRef artifact(EcmaToken token, ClrArtifactKind kind, string name)
            => new EcmaArtifactRef(token, kind, name);
    }
}