//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class CmdUri : Uri<CmdUri, UriSchemes.Cmd>
    {
        public readonly string Part;

        public readonly string Host;

        public readonly string Name;

        public readonly CmdKind Kind;

        public CmdUri()
        {
            Part = EmptyString;
            Host = EmptyString;
            Name = EmptyString;
            Kind = 0;
        }

        [MethodImpl(Inline)]
        internal CmdUri(CmdKind kind, string? part, string? host, string? name)
            : base(format(kind,part,host,name))

        {
            Kind = kind;
            Part = part ?? EmptyString;
            Host = host ?? EmptyString;
            Name = name ?? EmptyString;
            //Hash = hash(Part) | hash(Host) | hash(Name) | (Hash32)(byte)Kind;
        }

        // public bool Equals(CmdUri src)
        //     => Kind == src.Kind && Part == src.Part && Host == src.Host && Name == src.Name;

        // public bool IsEmpty
        // {
        //     [MethodImpl(Inline)]
        //     get => empty(Part) && empty(Host) && empty(Name);
        // }


        static string format(CmdKind _kind, string part, string host, string name)
        {
            var symbols = Symbols.index<CmdKind>();
            var symbol = Sym<CmdKind>.Empty;
            var kind = EmptyString;
            if(symbols.FindByKind(_kind, out symbol))
                kind = symbol.Expr.Format();
            else
                kind = _kind.ToString().ToLowerInvariant();
            return $"{kind}://{part}/{host}?name={name}";
        }

        // public string Format()
        // {
        //     var symbols = Symbols.index<CmdKind>();
        //     var symbol = Sym<CmdKind>.Empty;
        //     var kind = EmptyString;
        //     if(symbols.FindByKind(Kind, out symbol))
        //         kind = symbol.Expr.Format();
        //     else
        //         kind = Kind.ToString().ToLowerInvariant();
        //     return $"{kind}://{Part}/{Host}?name={Name}";
        // }


        // public override int GetHashCode()
        //     => Hash;

        // public override string ToString()
        //     => Format();                
        
    }
}