//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Symbolic
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref SymLiteral<E> symlit<E>(in Sym<E> src, out SymLiteral<E> dst)
            where E : unmanaged
        {
            var type = typeof(E);
            dst.Component = typeof(E).Assembly;
            dst.DataType = PrimalBits.kind(type);
            dst.Group = src.Group;
            dst.Size = src.Size;
            dst.Description = src.Description;
            dst.Value = src.Value;
            dst.Identity = src.Identity;
            dst.Name = src.Name;
            dst.Index = (uint)src.Key.Value;
            dst.Symbol = (src.Kind, src.Expr.Format());
            dst.Type = src.Type;
            dst.Hidden = src.Hidden;
            return ref dst;
        }
    }
}