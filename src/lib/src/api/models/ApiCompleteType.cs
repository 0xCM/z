//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ApiCompleteType : IApiHost, IComparable<ApiCompleteType>
    {
        public PartName PartName {get;}

        public Type HostType {get;}

        public Index<MethodInfo> Methods {get;}

        public ApiHostUri HostUri {get;}

        Dictionary<string,MethodInfo> Index {get;}

        [MethodImpl(Inline)]
        public ApiCompleteType(Type type, PartName part, ApiHostUri uri, Index<MethodInfo> methods, Dictionary<string,MethodInfo> index)
        {
            HostType = type;
            PartName = part;
            HostUri = uri;
            Methods = methods;
            Index = index;
        }

        public bool FindMethod(OpUri uri, out MethodInfo method)
            => Index.TryGetValue(uri.OpId.IdentityText, out method);

        [MethodImpl(Inline)]
        public string Format()
            => HostUri.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ApiCompleteType src)
            => src.HostType.Equals(HostType);

        [MethodImpl(Inline)]
        public int CompareTo(ApiCompleteType src)
            => ((long)src.HostType.TypeHandle.Value).CompareTo((long)HostType.TypeHandle.Value);

        public override int GetHashCode()
            => HostType.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator ApiHostUri(ApiCompleteType src)
            => src.HostUri;
    }
}