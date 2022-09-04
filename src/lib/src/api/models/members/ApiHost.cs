//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies/describes a type that declares a formalized api set
    /// </summary>
    public readonly struct ApiHost : IApiHost, IComparable<ApiHost>
    {
        public readonly Type HostType {get;}

        public readonly Identifier HostName {get;}

        public readonly _ApiHostUri HostUri {get;}

        public readonly Index<MethodInfo> Methods {get;}

        readonly Dictionary<string,MethodInfo> Index {get;}

        public readonly PartName PartName {get;}

        [MethodImpl(Inline)]
        public ApiHost(Type type, string name, PartName part, _ApiHostUri uri, MethodInfo[] methods, Dictionary<string,MethodInfo> index)
        {
            PartName = part;
            HostType = type;
            HostName = name;
            HostUri = uri;
            Methods = methods;
            Index = index;
        }

        public bool FindMethod(_OpUri uri, out MethodInfo method)
            => Index.TryGetValue(uri.OpId.IdentityText, out method);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => HostType == typeof(void);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => HostType != typeof(void);
        }

        [MethodImpl(Inline)]
        public string Format()
            => HostUri.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ApiHost src)
            => src.HostType.Equals(HostType);

        [MethodImpl(Inline)]
        public int CompareTo(ApiHost src)
            => ((long)src.HostType.TypeHandle.Value).CompareTo((long)HostType.TypeHandle.Value);

        public override int GetHashCode()
            => HostType.GetHashCode();

        public override bool Equals(object src)
            => src is ApiHost t && Equals(t);

        [MethodImpl(Inline)]
        public static implicit operator _ApiHostUri(ApiHost src)
            => src.HostUri;

        [MethodImpl(Inline)]
        public static bool operator==(ApiHost a, ApiHost b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(ApiHost a, ApiHost b)
            => !a.Equals(b);

        public static ApiHost Empty
            => new ApiHost(typeof(void), EmptyString, PartName.Empty, _ApiHostUri.Empty, sys.empty<MethodInfo>(), new());
    }
}