//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiCmdMethod : IComparable<ApiCmdMethod>, ICmdMethod
    {
        public readonly ApiCmdRoute Route;

        public readonly ApiActorKind Kind;

        public readonly object Host;

        public readonly MethodInfo Definition;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public ApiCmdMethod(ApiCmdRoute route, ApiActorKind kind, MethodInfo method, object host)
        {
            Route = route;
            Kind = kind;
            Host = Require.notnull(host);
            Definition = Require.notnull(method);
            Uri = ApiCmd.uri(route, host);
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Host.GetType();
        }

        ApiCmdRoute ICmdEffector.Route
            => Route;

        public int CompareTo(ApiCmdMethod src)
            => Format().CompareTo(src.Format());

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}