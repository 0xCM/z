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

        [MethodImpl(Inline)]
        public static ClrEnumAdapter<E> @enum<E>()
            where E : unmanaged, Enum
     
                => default;

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static bit deposit<T>(in T src, ref SymStore<T> dst, out SymRef s)
            => dst.Deposit(src, out s);

        [Op]
        public static uint example(SymStore<string> store, Span<SymRef> refs, Span<string> found)
        {
            var i=0u;
            var j=0u;
            var k=0u;
            store.Deposit("abc", out seek(refs,i++));
            store.Deposit("def", out seek(refs,i++));
            store.Deposit("hij", out seek(refs,i++));
            store.Deposit("klm", out seek(refs,i++));
            store.Deposit("nop", out seek(refs,i++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            return i;
        }

        public static void example()
        {
            var count = 12u;
            var store = Symbols.store<string>(count);
            var refs = sys.alloc<SymRef>(count);
            var found = sys.alloc<string>(count);

            store.Deposit("abc", out var s1);
            store.Deposit("def", out var s2);
            store.Deposit("hij", out var s3);
            store.Deposit("klm", out var s4);
            store.Deposit("nop", out var s5);

            var e1 = store.Find(s1);
            var e2 = store.Find(s2);
            var e3 = store.Find(s3);
            var e4 = store.Find(s4);
            var e5 = store.Find(s5);
        }
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