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
        public _ApiHostUri HostUri {get;}

        public PartName PartName {get;}

        public Index<MethodInfo> Methods {get;}

        public Type HostType {get;}

        Dictionary<string,MethodInfo> Index {get;}

        [MethodImpl(Inline)]
        public ApiHostInfo(Type host, _ApiHostUri uri, PartName part, MethodInfo[] methods, Dictionary<string,MethodInfo> index)
        {
            HostType = host;
            HostUri = uri;
            PartName = part;
            Methods = methods;
            Index = index;
        }

        public bool FindMethod(_OpUri uri, out MethodInfo method)
            => Index.TryGetValue(uri.OpId.IdentityText, out method);
    }
}