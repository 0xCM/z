//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ByteSpans
    {
        /// <summary>
        /// Returns the properties declared by a type that define bytespan resource content
        /// </summary>
        /// <typeparam name="T">The defining type</typeparam>
        public static Index<PropertyInfo> props(Type src)
            => src.StaticProperties().Where(p => p.PropertyType == typeof(ReadOnlySpan<byte>)).Array();

        public static string bytespan(BinaryResSpec src, int level = 2)
            => text.concat("public static ReadOnlySpan<byte> ",
            src.Identifier,
            Space,
            " => ",
            Space,
            $"new byte[{src.Encoded.Length}]",
            Chars.LBrace,
            src.Encoded.Format(HexOptionData.HexArrayOptions),
            Chars.RBrace,
            Chars.Semicolon
            );

        [MethodImpl(Inline), Op]
        public static ByteSpanSpec specify(Identifier name, BinaryCode data, bool @static = true)
            => new ByteSpanSpec(name, data, @static);

        [MethodImpl(Inline)]
        public static SymSpanSpec<E> specify<E>(Identifier name)
            where E : unmanaged, Enum
                => specify<E>(name, Symbols.index<E>().View);

        [MethodImpl(Inline)]
        public static SymSpanSpec<E> specify<E>(Identifier name, ReadOnlySpan<Sym<E>> literals, bool @static = true)
            where E : unmanaged, Enum
                => new SymSpanSpec<E>(name, literals, @static);
        [Op]
        public static ByteSpanSpec specify(OpUri uri, BinaryCode data, bool @static = true)
            => new ByteSpanSpec(LegalIdentityBuilder.code(uri.OpId), data, @static);

        public static Index<ReflectedByteSpan> reflected(Type[] src)
        {
            var props = src.StaticProperties().Where(p => p.GetGetMethod() != null && p.PropertyType == typeof(ReadOnlySpan<byte>)).ToReadOnlySpan();
            var count = props.Length;
            var dst = alloc<ReflectedByteSpan>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var prop = ref skip(props,i);
                var method = prop.GetGetMethod();
                seek(dst,i) = new ReflectedByteSpan(method.Artifact(), method.GetMethodBody().GetILAsByteArray());
            }
            return dst;
        }

       public Index<ByteSpanSpec> names<K>(Symbols<K> src)
            where K : unmanaged
        {
            var view = src.View;
            var count = view.Length;
            var dst = alloc<ByteSpanSpec>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = name(skip(view,i));
            return dst;
        }

        [Op]
        public static ByteSpanSpec merge(Identifier name, ByteSpanSpecs props)
        {
            var buffer = alloc<byte>(props.TotalSize);
            var c0 = props.Count;
            ref var dst = ref first(buffer);
            var view = props.View;
            var k=0;
            for(var i=0; i<c0; i++)
            {
                ref readonly var prop = ref skip(view,i);
                ref readonly var src = ref prop.FirstByte;
                var c1 = prop.Data.Count;
                for(var j=0; j<c1; j++, k++)
                    seek(dst,k) = skip(src,j);
            }
            return specify(name, buffer, props.First.IsStatic);
        }

        [MethodImpl(Inline), Op]
        public static CharSpanSpec charspan(Identifier name, string data, bool @static = true)
            => new CharSpanSpec(name, data, @static);

        [MethodImpl(Inline)]
        public static ByteSpanSpec<T> bytespan<T>(Identifier name, T[] data, bool @static = true)
            where T : unmanaged
                => new ByteSpanSpec<T>(name, data, @static);

        public ByteSpanSpec name<K>(Sym<K> src)
            where K : unmanaged
                => specify(src.Name, text.utf16(src.Name).ToArray());

        [Op]
        public static ApiHostRes hostres(ApiHostBlocks src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            var blocks = src.Blocks.View;
            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref skip(blocks,i);
                seek(dst,i) = new BinaryResSpec(LegalIdentityBuilder.code(code.Id), code.Encoded);
            }
            return new ApiHostRes(src.Host, buffer);
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<ByteSpanSpec> src)
        {
            var size = ByteSize.Zero;
            var count = src.Length;
            for(var i=0; i<count; i++)
                size += skip(src,i).DataSize;
            return size;
        }
    }
}