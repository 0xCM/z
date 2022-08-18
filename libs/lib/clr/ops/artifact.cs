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
        public static ClrArtifactRef artifact(CliToken token, ClrArtifactKind kind, string name)
            => new ClrArtifactRef(token, kind, name);

        /// <summary>
        /// Derives a signature from reflected method metadata
        /// </summary>
        /// <param name="src">The source method</param>
        [Op]
        public static ClrMethodArtifact artifact(MethodInfo src)
        {
            var dst = new ClrMethodArtifact();
            dst.Id = src.MetadataToken;
            dst.MethodName = src.DisplayName();
            dst.DefiningAssembly = src.Module.Assembly;
            dst.DefiningModule = src.Module.Name;
            dst.DeclaringType = src.DeclaringType.SigInfo();
            dst.ReturnType = src.ReturnType.SigInfo();
            dst.Args = src.GetParameters().Select(p => new ClrParamInfo(p.SigInfo(), p.RefKind(), p.Name, (ushort)p.Position));
            dst.TypeParameters = src.GenericParameters(false).Mapi((i,t) => t.DisplayName());
            return dst;
        }
    }
}