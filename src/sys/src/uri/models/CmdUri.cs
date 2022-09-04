//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a command handler
    /// </summary>
    public sealed record class CmdUri : Uri<CmdUri,UriSchemes.Cmd>
    {
        public readonly @string Scope;

        public readonly @string Host;

        public readonly @string Name;

        public readonly CmdKind Kind;

        public CmdUri()
        {
            Scope = EmptyString;
            Host = EmptyString;
            Name = EmptyString;
            Kind = 0;
        }

        [MethodImpl(Inline)]
        public CmdUri(CmdKind kind, string? scope, string? host, string? name)
            : base(_format(kind,scope,host,name))

        {
            Kind = kind;
            Scope = scope ?? EmptyString;
            Host = host ?? EmptyString;
            Name = name ?? EmptyString;
        }

        static string _format(CmdKind kind, string part, string host, string name)
            => $"{format(kind)}://{part}/{host}?name={name}";
    }
}