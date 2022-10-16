//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ClrArtifacts
    {
        /// <summary>
        /// Defines a reference to an artifact of parametric type
        /// </summary>
        /// <param name="src">The source artifact</param>
        /// <typeparam name="A">The artifact type</typeparam>
        [MethodImpl(Inline), Op]
        public static EcmaArtifactRef reference(EcmaToken id, ClrArtifactKind kind, string name)
            => new EcmaArtifactRef(id,kind,name);

        /// <summary>
        /// Defines a reference to an artifact of parametric type
        /// </summary>
        /// <param name="src">The source artifact</param>
        /// <typeparam name="A">The artifact type</typeparam>
        [MethodImpl(Inline)]
        public static EcmaArtifactRef reference<M>(M src)
            where M : MemberInfo
                => reference(src.MetadataToken, ClrArtifactKind.Field, src.Name);
    }
}