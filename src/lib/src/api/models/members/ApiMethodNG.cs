//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiMethodNG : IHostedApiMethod
    {
        /// <summary>
        /// The delcaring host
        /// </summary>
        public readonly IApiHost Host {get;}

        /// <summary>
        /// The operation identity
        /// </summary>
        public readonly _OpIdentity Id {get;}

        /// <summary>
        /// The concrete method that defines the operation
        /// </summary>
        public readonly MethodInfo Method {get;}

        /// <summary>
        /// Classifies the method as nongeneric
        /// </summary>
        public bool IsGeneric
            => false;

        [MethodImpl(Inline)]
        public ApiMethodNG(IApiHost host, _OpIdentity id, MethodInfo method)
        {
            Host = host;
            Id = id;
            Method = method;
        }

        _ApiHostUri IApiMethod.Host
            => Host.HostUri;

        public override string ToString()
            => Id;
    }
}