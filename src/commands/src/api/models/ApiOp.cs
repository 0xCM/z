//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiOp
    {
        public readonly Name CmdName;

        public readonly CmdActorKind Kind;

        public readonly object Host;

        public readonly MethodInfo Definition;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public ApiOp(Name name, CmdActorKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = Require.notnull(host);
            Definition = Require.notnull(method);
            Uri = ApiCmd.uri(name,host);
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Host.GetType();
        }

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}