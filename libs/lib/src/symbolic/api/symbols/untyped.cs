//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial struct Symbols
    {
        [Op, Closures(Closure)]
        internal static Sym untyped<T>(Sym<T> src)
            where T : unmanaged
                => new Sym(src.Identity, src.Group, src.Key, src.Type, bw64(src.Kind), src.Name, src.Expr.Text, src.Description, src.Hidden, src.Kind, src.Size);

        public static SymIndex untyped(Type src)
        {
            var factory = typeof(Symbols).Method("index").MakeGenericMethod(src);
            var index = (ISymIndex)factory.Invoke(null, array<object>());
            return index.Untyped();
        }
   }
}