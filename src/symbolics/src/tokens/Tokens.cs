//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using api = Tokens;

    [ApiHost]
    public class Tokens
    {
        public static void emit(IWfChannel channel, ITokenGroup src, IDbArchive dst)
            => channel.TableEmit(Symbols.syminfo(src.TokenTypes), dst.Table<SymInfo>($"{src.GroupName}"), TextEncodingKind.Unicode);

        public static ReadOnlySeq<Type> types(params Assembly[] src)
            => src.Enums().NonGeneric();

        public static G group<G,K>()
            where G : TokenGroup<G,K>, new()
            where K : unmanaged, Enum
        {
            var dst = new G();
            dst.Kinds = Symbols.index<K>();
            dst.KindCount = dst.Kinds.Count;
            var types = typeof(G).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();            
            dst.TypeKinds = types.Select(t => (t, (K)t.Tag<TokenKindAttribute>().Require().Kind)).ToDictionary();            
            dst.KindedTokens = alloc<Index<GroupedToken>>(dst.Kinds.Count);
            for(var i=0u; i<dst.Kinds.Count; i++)
                dst.KindedTokens[@as<K>(i)] = sys.empty<GroupedToken>();
            var counter = 0u;
            for(var i=0; i<types.Length; i++)
            {
                var kind = dst.TypeKinds[skip(types,i)];
                dst.KindedTokens[kind] = api.groups(skip(types,i));
                counter += dst.KindedTokens[kind].Count;
            }

            dst.TokenCount = counter;
            dst.Tokens = dst.KindedTokens.SelectMany(x => x).ToSeq();
            return dst;
        }

        public ReadOnlySeq<ITokenGroup> groups(params Assembly[] src)
            => src.TaggedTypes<TokenGroupAttribute>().Select(x=>x.Type).Where(x => x.IsConcrete()).Map(x => (ITokenGroup)Activator.CreateInstance(x));

        public static Index<GroupedToken> groups(Type src)
        {
            var symbols = api.symbols(src);
            var count = symbols.Length;
            var dst = alloc<GroupedToken>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                seek(dst,i) = new GroupedToken(symbol.Key,
                    text.ifempty(symbol.Group, EmptyString),
                    symbol.Type.Content,
                    symbol.Name,
                    text.ifempty(symbol.Expr.Text,symbol.Name),
                    symbol.Value
                    );
            }
            return dst;
        }

        [Op]
        public static uint traverse<T>(ReadOnlySpan<char> src, Action<TokenExpr<T>> receiver)
            where T : unmanaged, ICharBlock<T>
        {
            var counter = 0u;
            var data = src;
            var count = api.count(src);
            var expr = new T();
            var dst = expr.Data;
            var j=0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(i == count - 1)
                {
                    seek(dst,j++) = c;
                    if(j != 0)
                        receiver(new TokenExpr<T>(counter++, expr));
                }
                else if(SQ.@null(c))
                {
                    receiver(new TokenExpr<T>(counter++, expr));
                    expr = new T();
                    j=0u;
                }
                else
                    seek(dst,j++) = c;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static TokenExpr<T> expr<T>(uint id, T src)
            where T : unmanaged, ICharBlock
                => new TokenExpr<T>(id,src);

        [MethodImpl(Inline), Op]
        public static TokenExpr expr(uint id, ReadOnlySpan<char> src, uint offset, uint length)
            => new TokenExpr(id, address(skip(src,offset)),length);

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<char> src)
        {
            var counter = 0u;
            var length = src.Length;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.@null(c))
                    counter++;
                else if(i == length-1 && counter != 0)
                    counter++;
            }
            return counter;
        }

        public static Index<Token> tokenize(Type src)
        {
            var symbols = api.symbols(src);
            var count = symbols.Length;
            var dst = alloc<Token>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                seek(dst,i) = new Token(
                    symbol.Key,
                    symbol.Name,
                    text.ifempty(symbol.Expr.Text,symbol.Name)
                    );
            }
            return dst;
        }

        public static Index<Token<K>> tokenize<K>()
            where K : unmanaged, Enum
        {
            var symbols = Symbols.index<K>();
            var count = symbols.Length;
            var dst = alloc<Token<K>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                seek(dst,i) = new Token<K>(
                    symbol.Key,
                    symbol.Kind,
                    symbol.Name,
                    text.ifempty(symbol.Expr.Text,symbol.Name)
                    );
            }
            return dst;
        }

        static SymIndex symbols(Type src)
            => Symbols.untyped(src);
    }
}