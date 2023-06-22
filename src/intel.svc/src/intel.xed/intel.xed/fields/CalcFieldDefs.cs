//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static sys;

    partial class XedFields
    {
        public const byte FieldCount = 128;

        static uint bitwidth(NativeTypeWidth src)
        {
            var dst = (uint)src;
            if(dst == 1)
                dst = 8;
            return dst;
        }

        static uint width(Type src)
        {
            var result = z32;
            var attrib = src.Tag<DataWidthAttribute>();
            if(src.IsEnum)
                result = bitwidth(PrimalBits.width(Enums.@base(src)));
            else if(attrib.IsSome())
                result = attrib.MapRequired(w => w.NativeWidth == 0 ?  (uint)w.PackedWidth: (uint)w.NativeWidth);
            if(result != 0)
                return result;
            if(src == typeof(bit) || src == typeof(byte))
                result = 8;
            else if(src == typeof(ushort))
                result = 16;
            return result;
        }

        static Type[] CalcEffectiveTypes()
            => typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>().Select(x => x.Tag<RuleFieldAttribute>().Value.EffectiveType);

        static FieldDefs CalcFieldDefs()
        {
            var fields = typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = fields.Length;
            var defs = new FieldDefs(sys.alloc<FieldDef>(FieldCount), sys.alloc<FieldDef>(FieldCount));
            var positioned = defs.ByPos;
            var indexed = defs.Indexed;
            var packed = z32;
            var aligned = z32;

            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref var dst = ref positioned[i + 1];

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var awidth = width(field.FieldType);
                var pwidth = tag.Width;
                var index = (byte)tag.Kind;
                dst.Pos = i;
                dst.Field = tag.Kind;
                dst.Index = index;
                dst.DataType = tag.EffectiveType.DisplayName();
                dst.NativeType = field.FieldType.DisplayName();
                dst.PackedWidth = pwidth;
                dst.AlignedWidth = awidth;
                dst.PackedOffset = packed;
                dst.AlignedOffset = aligned;
                dst.Description = tag.Description;
                indexed[(FieldKind)index] = dst;
                packed += pwidth;
                aligned += awidth;
            }

            defs.SortIndex();
            return defs;
        }
    }
}