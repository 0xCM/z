//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        public static Index<char> concat<K>(Symbols<K> src)
            where K : unmanaged
        {
            var symbols = src.View;
            var count = symbols.Length;
            var size = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols,i);
                var id = s.Kind;
                var expr = s.Expr.Data;
                size += ((uint)expr.Length + 1);
            }

            var buffer = alloc<char>(size);
            ref var dst = ref first(buffer);
            var k=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols,i);
                var expr = s.Expr.Data;
                for(var j=0; j<expr.Length; j++)
                    seek(dst,k++) = (char)skip(expr,j);
                seek(dst,k++) = (char)0;
            }
            return buffer;
        }
    }
}