//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class CmdUri
    {
        public readonly string Part;

        public readonly string Host;

        public readonly string Name;

        public readonly CmdKind Kind;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        internal CmdUri(CmdKind kind, string? part, string? host, string? name)
        {
            Kind = kind;
            Part = part ?? EmptyString;
            Host = host ?? EmptyString;
            Name = name ?? EmptyString;
            Hash = hash(Part) | hash(Host) | hash(Name) | (Hash32)(byte)Kind;
        }

        public bool Equals(CmdUri src)
            => Kind == src.Kind && Part == src.Part && Host == src.Host && Name == src.Name;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Part) && empty(Host) && empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
        {
            var symbols = Symbols.index<CmdKind>();
            var symbol = Sym<CmdKind>.Empty;
            var kind = EmptyString;
            if(symbols.FindByKind(Kind, out symbol))
                kind = symbol.Expr.Format();
            else
                kind = Kind.ToString().ToLowerInvariant();
            return $"{kind}://{Part}/{Host}?name={Name}";
        }


        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();        

        static CmdUri _Empty = new CmdUri(CmdKind.None, EmptyString, EmptyString, EmptyString); 

        public static ref readonly CmdUri Empty => ref _Empty;
    }
}