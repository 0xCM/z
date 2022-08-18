//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPath : ITextual
    {
        readonly ApiHostUri Host;

        readonly string Operation;

        [MethodImpl(Inline)]
        public static ApiPath define(PartId part)
            => new ApiPath(part);

        [MethodImpl(Inline)]
        public static ApiPath define(PartId part, string host)
            => new ApiPath(part, host);

        [MethodImpl(Inline)]
        public static ApiPath define(ApiHostUri host)
            => new ApiPath(host);

        [MethodImpl(Inline)]
        public static ApiPath define(ApiHostUri host, string op)
            => new ApiPath(host, op);

        [MethodImpl(Inline)]
        public ApiPath(PartId part)
        {
            Host = new ApiHostUri(part, EmptyString);
            Operation = EmptyString;
        }

        [MethodImpl(Inline)]
        public ApiPath(PartId part, string host)
        {
            Host = new ApiHostUri(part, host);
            Operation = EmptyString;
        }

        [MethodImpl(Inline)]
        public ApiPath(ApiHostUri host)
        {
            Host = host;
            Operation = EmptyString;
        }

        [MethodImpl(Inline)]
        public ApiPath(ApiHostUri host, string operation)
        {
            Host = host;
            Operation = operation;
        }

        public string Format()
        {
            const string Pattern0 = "api://*/{0}";
            const string Pattern1 = "api://{0}";
            const string Pattern2 = "api://{0}/{1}";

            if(Host.IsEmpty)
                return string.Format(Pattern0, Operation);
            if(string.IsNullOrEmpty(Operation))
                return string.Format(Pattern1,Host);
            else
                return string.Format(Pattern2, Host, Operation);
        }

        public string MatchPattern()
        {
            if(Host.IsEmpty && string.IsNullOrEmpty(Operation))
                return EmptyString;

            if(Host.IsEmpty)
                return Operation;

            return string.Format("{0}.{1}", Host.Part.Format(), Host.HostName);
        }

        public override string ToString()
            => Format();

        public static ApiPath Empty
        {
            [MethodImpl(Inline)]
            get => new ApiPath(ApiHostUri.Empty);
        }
    }
}