//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiMethod : ITextual
    {
        OpIdentity Id {get;}

        /// <summary>
        /// The globally-unique host uri
        /// </summary>
        ApiHostUri Host {get;}

        /// <summary>
        /// The hosted method
        /// </summary>
        MethodInfo Method {get;}

        /// <summary>
        /// The clr metadata token
        /// </summary>
        EcmaToken Token
            => Method;

        /// <summary>
        /// The method's kind identifier if it exists
        /// </summary>
        ApiClassKind ApiClass
            => ApiClassKind.None;

        /// The globally-unique operation uri
        /// </summary>
        OpUri OpUri
            => ApiIdentity.hex(Host, Method.Name, Id);

        ClrMethodArtifact Metadata
            => Method.Artifact();

        string ITextual.Format()
            => OpUri.Format();
    }
}