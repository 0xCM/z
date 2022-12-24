//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedModels;
    using static XedOps;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Index<FieldValue> update(in DisasmBlock src, ref OperandState dst)
        {
            var fields = values(src);
            XedOps.update(fields, ref dst);
            return fields;
        }

        static Index<FieldValue> values(in DisasmBlock src)
        {
            parse(src, out InstFieldValues props);
            var state = OperandState.Empty;
            var names = props.Keys.Array();
            var count = names.Length;
            var dst = alloc<FieldValue>(count - 2);
            var k=0u;
            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                if(name == nameof(FieldKind.ICLASS) || name == nameof(InstForm))
                    continue;

                if(XedParsers.parse(name, out FieldKind kind))
                    seek(dst,k++) = FieldParser.parse(props[name], kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
            }
            return dst;
        }
    }
}