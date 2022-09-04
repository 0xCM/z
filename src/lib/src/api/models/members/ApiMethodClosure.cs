//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures identifying/descriptive information about a generic closure
    /// </summary>
    public readonly struct ApiMethodClosure : IHostedApiMethod
    {
        /// <summary>
        /// The delcaring host
        /// </summary>
        public IApiHost Host {get;}

        /// <summary>
        /// The closure identity
        /// </summary>
        public _OpIdentity Id {get;}

        /// <summary>
        /// The primal kind over which the subject operation was closed
        /// </summary>
        public NumericKind Kind {get;}

        /// <summary>
        /// The closed method
        /// </summary>
        public MethodInfo Method {get;}

        /// <summary>
        /// Spcifies the the method is closed generic
        /// </summary>
        public bool IsClosedGeneric
            => true;

        /// <summary>
        /// Initializes a closure specification
        /// </summary>
        /// <param name="id">The assigned identity</param>
        /// <param name="kind">The primal kind over which the subject was closed</param>
        /// <param name="closed">The closed method</param>
        [MethodImpl(Inline)]
        public ApiMethodClosure(IApiHost host, _OpIdentity id, NumericKind kind, MethodInfo method)
        {
            Host = host;
            Id = id;
            Kind = kind;
            Method = method;
        }
    }
}