//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class TextAssets
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static Index<StringRes> strings(Type src)
        {
            var values = ClrLiterals.values<string>(src);
            var count = values.Count;
            var buffer = alloc<StringRes>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref values[i];
                seek(dst,i) = new(fv.Left, fv.Right);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static Index<StringResRow> rows(ReadOnlySpan<StringRes> src)
            => src.Select(row);

        [MethodImpl(Inline), Op]
        public static StringResRow row(StringRes src)
        {
            var dst = new StringResRow();
            dst.Id = src.Source.MetadataToken;
            dst.Address = src.Value;
            dst.Length = (uint)src.Value.Length;
            return dst;
        }

        [Op, Closures(Closure)]
        public static Index<StringRes<T>> strings<T>(Type src)
            where T : unmanaged
        {
            var values = ClrLiterals.values<string>(src);
            var count = values.Count;
            var buffer = alloc<StringRes<T>>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref values[i];
                seek(dst,i) = @string(@as<uint,T>(i), fv.Right, (uint)fv.Right.Length*2);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRes<E> @string<E>(E id, StringAddress address, ByteSize size)
            where E : unmanaged
                => new StringRes<E>(id, address, size);

        [MethodImpl(Inline), Op]
        public static ResText restext(string src)
            => new ResText(new (address(src), src.Length));

        [MethodImpl(Inline), Op]
        public static ResText restext(ReadOnlySpan<char> src)
            => new ResText(new (address(src), src.Length));

        public static string format(ResText src)
        {
            Span<char> dst = stackalloc char[(int)src.Address.Length];
            var i=0u;
            var count = render(restext(src.Address.Cells), ref i, dst);
            return sys.@string(slice(dst,0,count));
        }

        [MethodImpl(Inline)]
        public static uint render(in ResText src, ref uint i, Span<char> dst)
            => text.render(src.Address.Cells, ref i, dst);
    }
}