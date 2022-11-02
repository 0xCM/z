//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Tables
    {
        [MethodImpl(Inline), Op]
        public static TableColumn column(string name, string type, ushort length)
            => new TableColumn(name, type, length);

        public static TableColumn column<K>(string name)
            where K : unmanaged, Enum
        {
            var kinds = Symbols.index<K>();
            var result = kinds.Lookup(name.Trim(), out var sym);
            var type = result ? sym.Expr.Format() : string.Format("!{0}!", name);
            var length = name.Length;
            return Tables.column(name.Trim(), type, (ushort)length);
        }

        public static Seq<TableColumn> columns<K>(ReadOnlySpan<string> src)
            where K : unmanaged, Enum
        {
            var count = src.Length;
            var buffer = alloc<TableColumn>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                seek(dst,i) = Tables.column<K>(skip(src,i));
            }
            return buffer;
        }
    }
}