//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        public static SymExpr expr<E>(E src)
            where E : unmanaged, Enum
        {
            var ix = index<E>();
            if(ix.FindByKind(src, out var sym))
                return sym.Expr;
            else
                return src.ToString();
        }

        /// <summary>
        /// Extracts the symbol expressions from a source buffer and deposits them in a caller-supplied target
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint expr<T>(Symbols<T> src, Span<SymExpr> dst)
            where T : unmanaged
        {
            var count = src.Length;
            var view = src.View;
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(view,i).Expr;
            return (uint)count;
        }

        [MethodImpl(Inline),Op, Closures(Closure)]
        public static uint expr<T>(Symbols<T> src, Span<text7> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            var symbols = src.View;
            for(var i=0; i<count; i++)
                seek(dst, i) = FixedChars.txt(n7, skip(symbols,i).Expr.Data);
            return count;
        }

        [MethodImpl(Inline),Op, Closures(Closure)]
        public static uint expr<T>(Symbols<T> src, Span<text15> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            var symbols = src.View;
            for(var i=0; i<count; i++)
                seek(dst, i) = FixedChars.txt(n15, skip(symbols,i).Expr.Data);
            return count;
        }

        [MethodImpl(Inline),Op, Closures(Closure)]
        public static uint expr<T>(Symbols<T> src, Span<text31> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            var symbols = src.View;
            for(var i=0; i<count; i++)
                seek(dst, i) = FixedChars.txt(n31, skip(symbols,i).Expr.Data);
            return count;
        }
    }
}