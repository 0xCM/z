//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    partial class Generators
    {
        class TokenTemplate<K,V> : Template<TokenTemplate<K,V>,TokenLift<K,V>>
            where K : new()
            where V : new()
        {
            const string Template=
    @"export type ${Key} = '${Value}'
    export function ${Key}() : ${Key} {
        return '${Value}'
    }
    ";
            static readonly Dictionary<string,List<byte>> Positions;

            static TokenTemplate()
            {
                Positions = new ();
                Positions["${Key}"] = sys.list<byte>(0,2,3);
                Positions["${Value}"] = sys.list<byte>(1,4);
            }

            K _Key;

            V _Value;

            public TokenTemplate()
            {
                _Key = new();
                _Value = new();

            }

            public TokenTemplate(K key, V value)
            {
                _Key = key;
                _Value = value;
            }

            public override TokenTemplate<K,V> Bind(TokenLift<K,V> src)
                => new (src.Key,src.Value);

            public override string Format()
            {
                return "";
            }

            protected override string Expr()
                => Template;
        }
    }    
}