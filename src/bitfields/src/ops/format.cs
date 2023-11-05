//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    public static string format(in BfSegDef src)
    {
        if(src.Width == 1)
            return string.Format("{0}[{1}]", src.SegName, src.MinPos);
        else
            return string.Format("{0}[{1}:{2}]", src.SegName, endpos(src.MinPos, src.Width), src.MinPos);
    }

    public static string format<K>(in BfSegDef<K> src)
        where K : unmanaged
    {
        if(src.Width == 1)
            return string.Format("{0}[{1}]", src.SegName, src.MinPos);
        else
            return string.Format("{0}[{1}:{2}]", src.SegName, endpos(src.MinPos, src.Width), src.MinPos);
    }
        
    public static string format<E>(BitVector64<E> src)
        where E : unmanaged, Enum
    {
        var symbols = Symbols.index<E>();
        var count = min(symbols.Length, 64);
        var dst = text.emitter();
        for(var i=z8; i<count; i++)
        {
            if(src[i])
            {
                if(i>0)
                    dst.Append(", ");
                dst.Append(symbols[i].Name);
            }
        }
        return dst.Emit();
    }

    [Op]
    public static string format(Bitfield8 src)
    {
        var buffer = CharBlock16.Null.Data;
        var count = render(src, buffer);
        return new string(slice(buffer, 0, count));
    }


    [Op]
    public static string format(Bitfield16 src)
    {
        var buffer = CharBlock32.Null.Data;
        var count = render(src, buffer);
        return new string(slice(buffer, 0, count));
    }

    [Op]
    public static string format(Bitfield32 src)
    {
        var buffer = CharBlock64.Null.Data;
        var count = render(src, buffer);
        return new string(slice(buffer, 0, count));
    }

    [Op]
    public static string format(Bitfield64 src)
    {
        var buffer = CharBlock128.Null.Data;
        var count = render(src, buffer);
        return new string(slice(buffer, 0, count));
    }

    /// <summary>
    /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
    /// </summary>
    /// <param name="value">The field value</param>
    /// <typeparam name="E">The field value type</typeparam>
    /// <typeparam name="T">The field data type</typeparam>
    public static string format<E,T>(E src, int? zpad = null)
        where E : unmanaged, Enum
        where T : unmanaged
            => format<E,T>(src, typeof(E).Name, zpad);

    /// <summary>
    /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
    /// </summary>
    /// <param name="value">The field value</param>
    /// <typeparam name="E">The field value type</typeparam>
    /// <typeparam name="T">The field data type</typeparam>
    public static string format<E,T>(E src, string name, int? zpad = null)
        where E : unmanaged, Enum
        where T : unmanaged
    {
        var data = Enums.scalar<E,T>(src);
        var limit = gbits.effwidth(data);
        var config = BitFormatter.limited(limit,zpad);
        var formatter = BitRender.formatter<T>(config);
        return string.Concat(name, Chars.Colon, formatter.Format(data));
    }


    public static string format(ReadOnlySpan<BfInterval> src)
    {
        var dst = text.buffer();
        var count = src.Length;
        for(var i=count-1; i>= 0; i--)
        {
            if(i != count-1)
            {
                dst.Append(Chars.Space);
                dst.Append(Chars.Pipe);
                dst.Append(Chars.Space);
            }

            dst.Append(skip(src,i));

        }
        return dst.Emit();
    }

    public static string format<F>(ReadOnlySpan<BfInterval<F>> src)
        where F : unmanaged
    {
        var dst = text.buffer();
        var count = src.Length;
        for(var i=count-1; i>= 0; i--)
        {
            if(i != count-1)
            {
                dst.Append(Chars.Space);
                dst.Append(Chars.Pipe);
                dst.Append(Chars.Space);
            }

            dst.Append(skip(src,i));

        }
        return dst.Emit();
    }

    public static string format(in BfDef src)
    {
        static string typename(in BfDef src)
            => src.IsBitvector ? "bitvector" : "bitfield";

        static string decl(in BfDef src)
            => string.Format("{0} : {1}<{2}> " , src.Name, typename(src), src.Size.Packed);

        var dst = text.buffer();
        dst.AppendLine(decl(src) + Chars.LBrace);
        var indent = 2u;
        var count = (int)src.SegCount;

        for(var i=count-1; i>=0; i--)
        {
            if(i != count - 1)
                dst.IndentLineFormat(indent, "{0},", Bitfields.expr(skip(src.Segments,i)));
            else
                dst.IndentLineFormat(indent, "{0}", Bitfields.expr(skip(src.Segments,i)));
        }
        indent -= 2;
        dst.IndentLine(indent,Chars.RBrace);
        return dst.Emit();
    }
}
