//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an api host
    /// </summary>
    public readonly struct ApiHostInfo : IApiHost
    {
        public ApiHostUri HostUri {get;}

        public PartId PartId {get;}

        public Index<MethodInfo> Methods {get;}

        public Type HostType {get;}

        Dictionary<string,MethodInfo> Index {get;}

        [MethodImpl(Inline)]
        public ApiHostInfo(Type host, ApiHostUri uri, PartId part, MethodInfo[] methods, Dictionary<string,MethodInfo> index)
        {
            HostType = host;
            HostUri = uri;
            PartId = part;
            Methods = methods;
            Index = index;
        }

        public bool FindMethod(OpUri uri, out MethodInfo method)
            => Index.TryGetValue(uri.OpId.IdentityText, out method);
    }
}