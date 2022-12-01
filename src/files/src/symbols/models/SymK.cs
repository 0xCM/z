//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Symbols;

    public class Sym<K> : ISym<K>
        where K : unmanaged
    {
        public SymIdentity Identity {get;}

        public SymKey Key {get;}

        public string Name {get;}

        public string Group {get;}

        public K Kind {get;}

        public SymExpr Expr {get;}

        public TextBlock Description {get;}

        public bool Hidden {get;}

        public SymVal Value {get;}

        public readonly DataSize Size;

        Sym()
        {
            Identity = SymIdentity.Empty;
            Key = default;
            Name = Identifier.Empty;
            Kind = default;
            Expr = SymExpr.Empty;
            Description = TextBlock.Empty;
            Hidden = true;
            Group = EmptyString;
            Value = SymVal.Zero;
            Size = DataSize.Zero;
        }

        [MethodImpl(Inline)]
        internal Sym(uint index, SymLiteral<K> src)
        {
            Identity = src.Identity;
            Key = index;
            Group = src.Group;
            Kind = src.Symbol.Kind;
            Name = src.Name;
            Expr = src.Symbol;
            Description = src.Description;
            Hidden = src.Hidden;
            Value = src.Value;
            Size = Sizes.measure(typeof(K));
        }

        public Identifier Type
            => typeof(K).Name;

        public string Format()
            => string.Format(Sym.RenderPattern, Key, Type, Name, Expr, Kind, Description);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator K(Sym<K> src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator Sym(Sym<K> src)
            => api.untyped(src);

        public static Sym<K> Empty
        {
            [MethodImpl(Inline)]
            get => new Sym<K>();
        }
    }
}