//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static CsPatterns;
using static CsLiterals;

[ApiHost]
public class ByteSpans
{
    public static ByteSpanSpec ascirender(uint indent, Identifier name, string data, ITextBuffer dst)
    {
        var payload = text.buffer();
        var src = span(data);
        var count = src.Length;
        var buffer = alloc<byte>(count);
        ref var target = ref first(buffer);
        for(var i=0; i<count; i++)
            seek(target, i) = (byte)skip(src,i);
        var spec = specify(name, buffer, true);
        ascirender(indent, spec, dst);
        return spec;
    }

    [Op]
    public static void ascirender(uint indent, ByteSpanSpec spec, ITextBuffer dst)
    {
        var data = spec.Data.View;
        var size = spec.DataSize;
        var left = text.buffer();
        var modifiers = spec.IsStatic ? string.Format("{0} {1}", @public, @static) : @public;
        left.Append(modifiers);
        left.Append(Chars.Space);
        left.Append(ReadOnlySpanTypePattern.Format(spec.CellType));
        left.Append(Chars.Space);
        left.Append(spec.Name);

        var content = text.buffer();
        content.Append(Open());

        for(var i=0; i<size; i++)
        {
            ref readonly var cell = ref skip(data,i);
            if(i != size - 1)
                content.Append(string.Format("{0}, ", cell));
            else
                content.Append(string.Format("{0}", cell));
        }

        content.AppendFormat("{0}{1}", Close(), Chars.Semicolon);

        var right = text.buffer();
        right.Append(string.Concat(string.Format("new {0}", spec.CellType), text.bracket(size), content.Emit()));

        dst.IndentLine(indent, ExpressionBody.Format(left.Emit(), right.Emit()));
    }

    public static void symrender<E>(Identifier container, ITextBuffer dst)
        where E : unmanaged, Enum
    {
        var n = 0u;
        var type = typeof(E);
        var IndexName = "Index";
        dst.IndentLineFormat(n, "{0} {1}", @namespace, "Z0");
        dst.IndentLine(n, Open());
        n+= 4;
        dst.IndentLineFormat(n, "{0} {1}{2}", @using, nameof(System), Term());
        if(type.IsNested)
            dst.IndentLineFormat(n, "{0} {1} {2}{3}", @using, @static, type.DeclaringType.DottedName(), Term());
        dst.IndentLineFormat(n, "{0} {1} {2}{3}", @using, @static, type.DottedName(), Term());

        dst.AppendLine();
        dst.IndentLineFormat(n, "{0} {1} {2} {3}", @public, Readonly(), @struct, container);
        dst.IndentLine(n, Open());
        n+=4;

        var spec = specify<E>(IndexName);
        symrender(n, spec, dst, false);
        dst.IndentLine(n, Close());
        n-=4;
        dst.IndentLine(n, Close());
    }

    [Op]
    public static void symrender<T>(uint indent, SymSpan<T> spec, ITextBuffer dst, bool compact)
        where T : unmanaged
    {
        var payload = text.buffer();
        sympayload(indent, spec, payload, compact);
        var left = text.buffer();
        var modifiers = spec.IsStatic ? string.Format("{0} {1}", @public, @static) : @public;
        left.Append(modifiers);
        left.Append(Chars.Space);
        left.Append(ReadOnlySpanTypePattern.Format(spec.CellType));
        left.Append(Chars.Space);
        left.Append(spec.Name);

        var right = text.buffer();
        right.Append(string.Concat(string.Format("new {0}", spec.CellType), text.bracket(spec.Data.Length), payload.Emit()));

        var assignment = ExpressionBody.Format(left.Emit(), right.Emit());
        dst.IndentLine(indent, assignment);
    }

    static void sympayload<T>(uint indent, in SymSpan<T> spec, ITextBuffer dst, bool compact)
        where T : unmanaged
    {
        dst.Append(Open());
        if(compact)
        {
            symlist(spec.Data, dst);
            dst.AppendFormat("{0}{1}", Close(), Term());
        }
        else
        {
            symlines(indent + 4, spec.Data, dst);
            dst.IndentLineFormat(indent + 4, "{0}{1}", Close(), Term());
        }
    }

    static void symliteral<T>(uint indent, in Sym<T> src, ITextBuffer dst)
        where T : unmanaged
    {
        if(src.Description.IsNonEmpty)
            CsModels.comment(src.Description).Render(indent, dst);
        dst.IndentLineFormat(indent, "{0},", src.Name);
    }

    static void symlines<T>(uint indent, ReadOnlySpan<Sym<T>> src, ITextBuffer dst)
        where T : unmanaged
    {
        var count = src.Length;
        dst.AppendLine();
        for(var i=0; i<count; i++)
            symliteral(indent, skip(src,i), dst);
        dst.AppendLine();
    }

    static void symlist<T>(ReadOnlySpan<Sym<T>> src, ITextBuffer dst)
        where T : unmanaged
    {
        var count = src.Length;
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref skip(src,i);
            if(i != count - 1)
                dst.Append(string.Format("{0}, ", cell.Name));
            else
                dst.Append(cell.Name);
        }
    }
        
    [Op]
    public static string format(ByteSpanSpec src)
    {
        var dst = text.buffer();
        render(src, dst);
        return dst.Emit();
    }

    [Op]
    public static string format(CharSpanSpec src)
    {
        var dst = text.buffer();
        render(src, dst);
        return dst.Emit();
    }

    [Op]
    public static string format<T>(ByteSpanSpec<T> src)
        where T : unmanaged
    {
        var dst = text.buffer();
        render(src, dst);
        return dst.Emit();
    }

    public static string format<T>(SymSpan<T> src)
        where T : unmanaged
    {
        var dst = text.buffer();
        var margin = 0u;
        render(margin,src,dst);
        return dst.Emit();
    }

    public static string format<T>(ReadOnlySpan<Sym<T>> src)
        where T : unmanaged
    {
        var dst = text.buffer();
        var count = src.Length;
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref skip(src,i);
            if(i != count - 1)
                dst.Append(string.Format("{0}, ", cell));
            else
                dst.Append(cell.ToString());
        }
        return dst.Emit();
    }

    [Op]
    public static void render(ByteSpanSpec src, ITextBuffer dst)
        => render(src, HexFormatter.array<byte>(src.Data), dst);

    [Op]
    public static void render<T>(ByteSpanSpec<T> src, ITextBuffer dst)
        where T : unmanaged
    {
        var bytes = recover<T,byte>(src.Data.View);
        var payload = HexFormatter.array<byte>(bytes);
        dst.Append("public");
        dst.Append(Chars.Space);
        dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
        dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
        dst.Append(Chars.Space);
        dst.Append(src.Name);
        dst.Append(" => ");
        dst.Append(string.Concat(string.Format("new {0}", src.CellType), text.bracket(bytes.Length), text.embrace(payload)));
        dst.Append(Chars.Semicolon);
    }

    [Op]
    public static void render(CharSpanSpec src, ITextBuffer dst)
    {
        dst.Append("public");
        dst.Append(Chars.Space);
        dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
        dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
        dst.Append(Chars.Space);
        dst.Append(src.Name);
        dst.Append(" => ");

        var data = src.Data;
        var count = data.Length;

        dst.Append(string.Concat(string.Format("new {0}", src.CellType), text.bracket(count)));
        dst.Append(Open());

        for(var i=0; i<src.Data.Length; i++)
            dst.AppendFormat("'{0}',", skip(data,i));

        dst.Append(Close());
        dst.Append(Term());
    }

    public static void render<T>(uint margin, SymSpan<T> src, ITextBuffer dst)
        where T : unmanaged
    {
        var tmp = text.buffer();
        tmp.Append("public");
        tmp.Append(Chars.Space);
        tmp.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
        tmp.Append(ReadOnlySpanTypePattern.Format(src.CellType));
        tmp.Append(Chars.Space);
        tmp.Append(src.Name);
        tmp.Append(" => ");
        tmp.Append(string.Concat(string.Format("new {0}", src.CellType), text.bracket(src.Data.Length), text.embrace(format(src.Data))));
        tmp.Append(Term());
        dst.IndentLine(margin,tmp.Emit());
    }

    [Op]
    public static void render(ByteSpanSpec src, string payload, ITextBuffer dst)
    {
        dst.Append("public");
        dst.Append(Chars.Space);
        dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
        dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
        dst.Append(Chars.Space);
        dst.Append(src.Name);
        dst.Append(" => ");
        dst.Append(string.Concat(string.Format("new {0}", src.CellType), text.bracket(src.Data.Length), text.embrace(payload)));
        dst.Append(Term());
    }


    /// <summary>
    /// Returns the properties declared by a type that define bytespan resource content
    /// </summary>
    /// <typeparam name="T">The defining type</typeparam>
    public static Index<PropertyInfo> props(Type src)
        => src.StaticProperties().Where(p => p.PropertyType == typeof(ReadOnlySpan<byte>)).Array();

    public static string bytespan(BinaryResSpec src, int level = 2)
        => text.concat("public static ReadOnlySpan<byte> ",
        src.Name,
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
    public static SymSpan<E> specify<E>(Identifier name)
        where E : unmanaged, Enum
            => specify<E>(name, Symbols.index<E>().View);

    [MethodImpl(Inline)]
    public static SymSpan<E> specify<E>(Identifier name, ReadOnlySpan<Sym<E>> literals, bool @static = true)
        where E : unmanaged, Enum
            => new SymSpan<E>(name, literals, @static);
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

}
