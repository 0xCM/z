//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiNaturalOp : IHostedApiMethod
    {
        /// <summary>
        /// The operation host to which generic definition and any concrete closures belong
        /// </summary>
        public readonly IApiHost Host {get;}

        /// <summary>
        /// The generic operation identity
        /// </summary>
        public readonly OpIdentityG GenericId {get;}

        /// <summary>
        /// The supported closures
        /// </summary>
        public readonly NaturalNumericClosure[] Closures {get;}

        /// <summary>
        /// The generic method definition
        /// </summary>
        public readonly MethodInfo Method {get;}

        [MethodImpl(Inline)]
        public ApiNaturalOp(IApiHost host, OpIdentityG id, MethodInfo method, NaturalNumericClosure[] closures)
        {
            Host = host;
            GenericId = id;
            Method = method;
            Closures = closures;
        }

        /// <summary>
        /// The generalized identity
        /// </summary>
        public OpIdentity Id
            => GenericId.Generalize();

        ApiHostUri IApiMethod.Host
                => Host.HostUri;
    }
}