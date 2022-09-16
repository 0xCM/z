//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
        public static string format<E>(E src)
            where E : unmanaged, Enum
                => expr(src).Format();

        public static string header()
            => string.Format(Sym.RenderPattern, "Index", "Kind", "Name", "Expression", "Value", "Description");
    }
}