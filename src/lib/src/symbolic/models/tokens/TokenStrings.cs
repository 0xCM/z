//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public readonly struct TokenStrings
    {
        [MethodImpl(Inline), Op]
        public static TokenString define(char[] src)
            => new TokenString(src);

        [MethodImpl(Inline), Op]
        public static TokenExpr<T> expr<T>(uint id, T src)
            where T : unmanaged, ICharBlock<T>
                => new TokenExpr<T>(id,src);

        [MethodImpl(Inline), Op]
        public static TokenExpr expr(uint id, ReadOnlySpan<char> src, uint offset, uint length)
        {
            ref readonly var c = ref skip(src,offset);
            var location = address(c);
            return new TokenExpr(id, location,length);
        }

        [MethodImpl(Inline), Op]
        public static uint count(in TokenString src)
        {
            var counter = 0u;
            var data = src.Data;
            var length = data.Length;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(SQ.@null(c))
                    counter++;
                else if(i == length-1 && counter != 0)
                    counter++;
            }
            return counter;
        }

        [Op]
        public static uint walk<T>(in TokenString src, Action<TokenExpr<T>> receiver)
            where T : unmanaged, ICharBlock<T>
        {
            var counter = 0u;
            var data = src.Data;
            var count = src.TokenCount;
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
    }
}