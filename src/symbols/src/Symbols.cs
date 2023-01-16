//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    [ApiHost]
    public readonly partial struct Symbols
    {
        static int SegCount;

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(ushort capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));

        [Op, Closures(UInt64k)]
        public static SymStore<T> store<T>(uint capacity)
            => new SymStore<T>((uint)inc(ref SegCount), sys.alloc<T>(capacity));

        [MethodImpl(Inline), Op]
        static uint copy(ReadOnlySpan<char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = skip(src,j);
            return i - i0;
        }

        static string Table<K>(string name = null)
            where K : unmanaged
                => name ?? (typeof(K).Name + "ST");

        static string Index<K>(string name = null)
            where K : unmanaged
                => name ?? typeof(K).Name;

        static string IndexNs<K>(string name = null)
            where K : unmanaged
                => name ?? "Z0";

        static string TableNs<K>(string name = null)
            where K : unmanaged
                => name ?? "Z0.Strings";

        [Op,Closures(Closure)]
        public static ItemList<K,string> expressions<K>(Symbols<K> src, string name = null)
            where K : unmanaged
                => new ItemList<K,string>(name ?? (typeof(K).Name + "Expressions"),
                    src.Storage.Select(x => new ListItem<K,string>(x, x.Expr.Text)));
        [Op,Closures(Closure)]
        public static ItemList<ushort,string> expressions<K>(Symbols<K> src, W16 w, string name = null)
            where K : unmanaged
                => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Expressions"),
                    src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Expr.Text)));

        [Op,Closures(Closure)]
        public static ItemList<K,string> names<K>(Symbols<K> src, string name = null)
            where K : unmanaged
                => new ItemList<K,string>(name ?? (typeof(K).Name + "Names"),
                    src.Storage.Select(x => new ListItem<K,string>(x,x.Name)));

        [Op,Closures(Closure)]
        public static ItemList<ushort,string> names<K>(Symbols<K> src, W16 w, string name = null)
            where K : unmanaged
                => new ItemList<ushort,string>(name ?? (typeof(K).Name + "Names"),
                    src.Storage.Select(x => new ListItem<ushort,string>((ushort)x.Value,x.Name)));

        const NumericKind Closure = UnsignedInts;
    }
}