//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AppCmdDef : ICmdDef
    {
        public readonly Name CmdName;

        public readonly CmdActorKind Kind;

        public readonly object Host;

        public readonly MethodInfo Method;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public AppCmdDef(string name, CmdActorKind kind, MethodInfo method, object host)
        {
            CmdName = Require.notnull(name);
            Kind = kind;
            Host = Require.notnull(host);
            Method = Require.notnull(method);
            Uri = Cmd.uri(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), CmdName);
        }

        CmdUri ICmdDef.Uri 
            => Uri;

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}