//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AppCmdMethod : ICmdDef
    {
        public readonly Name CmdName;

        public readonly CmdActorKind Kind;

        public readonly object Host;

        public readonly MethodInfo Definition;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public AppCmdMethod(Name name, CmdActorKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = Require.notnull(host);
            Definition = Require.notnull(method);
            Uri = new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), CmdName);
        }

        CmdUri ICmdDef.Uri 
            => Uri;

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}