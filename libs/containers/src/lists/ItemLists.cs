//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct ItemLists
    {
        const NumericKind Closure = UnsignedInts;

        public static ItemList<Constant<T>> constants<T>(string name, T[] src)
            => new (name, src.Mapi((i,x) => new ListItem<Constant<T>>((uint)i,x)));

        public static ItemList<K,T> items<K,T>(ConstLookup<K,T> src)
            where K : unmanaged
            where T : IListItem<K,T>
                => src.MapValues(v => new ListItem<K,T>(v.Key, v.Value));

        [Op, Closures(Closure)]
        public static Index<ListItem<T>> items<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var buffer = alloc<ListItem<T>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (i,skip(src,i));
            return buffer;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ListItem<T> item<T>(uint index, T value)
            => (index,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ItemList<T> list<T>(ListItem<T>[] src)
            => new ItemList<T>(src);

        public static string format<T>(ItemList<T> src, Func<ListItem<T>,string> render)
        {
            var count = src.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
                dst.AppendLine(render(src[i]));
            return dst.Emit();
        }

        public static string format<K,T>(ItemList<K,T> src, Func<ListItem<K,T>,string> render)
            where K : unmanaged
        {
            var count = src.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
                dst.AppendLine(render(src[i]));
            return dst.Emit();
        }

        public static ListItem untype<T>(ListItem<T> src)
            => new ListItem(src.Key, text.trim(src.Value?.ToString() ?? EmptyString));

        public static Outcome list(FilePath src, bool header, char sep, IParser<object> parser, out ListItem[] dst)
        {
            dst = array<ListItem>();
            var buffer = core.list<ListItem>();
            using var reader = src.Utf8LineReader();
            if(header)
                reader.Next(out _);

            while(reader.Next(out var line))
            {
                var result = parse(line.Content, sep, parser, out var item);
                if(result.Fail)
                    return result;

                buffer.Add(item);
            }

            dst = buffer.ToArray();
            return true;
        }

        public static Outcome parse(string src, char sep, IParser<object> parser, out ListItem dst)
        {
            dst = default;
            var parts = src.SplitClean(sep);
            if(parts.Length < 2)
                return (false, "A list item requires at least two fields");

            var result = Outcome.Success;
            result = uint.TryParse(skip(parts,0), out var key);
            if(result.Fail)
                return result;

            var data = text.trim(skip(parts, 1));
            result = parser.Parse(data, out var value);
            if(result.Fail)
                return result;

            dst = new ListItem(key,value);
            return result;
        }
    }
}