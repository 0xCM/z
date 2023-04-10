//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdMethod : IComparable<CmdMethod>
    {
        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        public static CmdUri uri(string name, object host)
            => new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), name);

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var host = src.DeclaringType;
            var name = src.Tag<CmdOpAttribute>().MapValueOrElse(a => a.Name, () => src.DisplayName());
            return uri(CmdKind.App, host.Assembly.PartName().Format(), host.DisplayName(), name);        
        }
        
        public readonly @string CmdName;

        public readonly CmdActorKind Kind;

        public readonly object Host;

        public readonly MethodInfo Definition;

        public readonly CmdUri Uri;

        [MethodImpl(Inline)]
        public CmdMethod(string name, CmdActorKind kind, MethodInfo method, object host)
        {
            CmdName = name;
            Kind = kind;
            Host = Require.notnull(host);
            Definition = Require.notnull(method);
            Uri = uri(name,host);
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Host.GetType();
        }

        public int CompareTo(CmdMethod src)
            => Format().CompareTo(src.Format());

        public string Format()
            => Uri.Format();

        public override string ToString()
            => Format();
    }
}