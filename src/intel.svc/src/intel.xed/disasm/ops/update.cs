//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

partial class XedDisasm
{    
    public static void update(in XedDisasmBlock src, ref XedFieldState dst)
    {
        var vals = values(src);
        XedFieldParser.update(vals, ref dst);    
    }

    public static uint update(in XedDisasmBlock src, Span<FieldValue> buffer, ref XedFieldState dst)
    {
        var count = values(src, buffer);
        XedFieldParser.update(slice(buffer,0, count), ref dst);
        return count;
    }

    static uint values(in XedDisasmBlock src, Span<FieldValue> dst)
    {
        parse(src, out InstFieldValues props);
        var state = XedFieldState.Empty;
        var names = props.Keys.Array();
        var count = (uint)min(names.Length, dst.Length);
        //var dst = alloc<FieldValue>(count - 2);
        var k=0u;
        for(var i=0; i<count; i++)
        {
            var name = skip(names,i);
            if(name == nameof(FieldKind.ICLASS) || name == nameof(XedInstForm))
                continue;

            if(XedParsers.parse(name, out FieldKind kind))
                seek(dst,k++) = XedFieldParser.parse(props[name], kind, ref state);
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
        }
        return count;
    }

    static Index<FieldValue> values(in XedDisasmBlock src)
    {
        parse(src, out InstFieldValues props);
        var state = XedFieldState.Empty;
        var names = props.Keys.Array();
        var count = names.Length;
        var dst = alloc<FieldValue>(count - 2);
        var k=0u;
        for(var i=0; i<count; i++)
        {
            var name = skip(names,i);
            if(name == nameof(FieldKind.ICLASS) || name == nameof(XedInstForm))
                continue;

            if(XedParsers.parse(name, out FieldKind kind))
                seek(dst,k++) = XedFieldParser.parse(props[name], kind, ref state);
            else
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
        }
        return dst;
    }
}
