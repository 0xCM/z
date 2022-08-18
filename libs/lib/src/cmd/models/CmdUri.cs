//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public record struct CmdUri
    {
        readonly Seq<object> Components;

        public readonly Hash32 Hash;

        public ref CmdKind Kind 
        {
            [MethodImpl(Inline)]
            get => ref @as<object,CmdKind>(Components[0]);
        }

        public ref string Part 
        {
            [MethodImpl(Inline)]
            get => ref @as<object,string>(Components[1]);
        }

        public ref string Host 
        {
            [MethodImpl(Inline)]
            get => ref @as<object,string>(Components[2]);
        }

        public ref string Name 
        {
            [MethodImpl(Inline)]
            get => ref @as<object,string>(Components[3]);
        }

        [MethodImpl(Inline)]
        internal CmdUri(CmdKind kind, string? part, string? host, string? name)
        {
            Components = sys.alloc<object>(6);
            Hash = hash(part) | hash(host) | hash(name) | (Hash32)(byte)kind;
            Kind = kind;
            Part = ifempty(part,EmptyString);
            Host = ifempty(host,EmptyString);
            Name = ifempty(name,EmptyString);
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