//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using CK = XedRules.RuleCellKind;

partial class XedRules
{
    public class FieldDefs
    {
        [MethodImpl(Inline)]
        public static ref readonly FieldDef field(FieldKind kind)
            => ref Instance[kind];

        public static DataSize size(FieldKind fk, CK ck)
        {
            var dst = field(fk).Size;
            switch(ck)
            {
                case CK.Keyword:
                    dst = RuleKeyword.DataSize;
                break;
                case CK.NtCall:
                    dst = Nonterminal.DataSize;
                break;
                case CK.Operator:
                    dst = RuleOperator.DataSize;
                break;
            }
            return dst;
        }

        static readonly FieldDefs _Instance = fields();

        public static ref readonly FieldDefs Instance => ref _Instance;
        
        internal readonly Index<FieldDef> Indexed;

        [MethodImpl(Inline)]
        internal FieldDefs(Index<FieldDef> indexed)
        {
            Indexed = indexed;
        }

        public void SortIndex()
        {
            Indexed.Storage.Sort();
        }

        public byte Count
        {
            [MethodImpl(Inline)]
            get => (byte)Indexed.Count;
        }

        public ref FieldDef this[FieldKind kind]
        {
            [MethodImpl(Inline)]
            get => ref Indexed[(uint)kind];
        }

        public ref FieldDef this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Indexed[i];
        }

        public ref FieldDef this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Indexed[i];
        }

        public ReadOnlySpan<FieldDef> View
        {
            [MethodImpl(Inline)]
            get => Indexed.View;
        }        

        [MethodImpl(Inline)]
        public static implicit operator Index<FieldDef> (FieldDefs src)
            => src.Indexed.Storage;

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

        static FieldDefs fields()
        {
            var fields = typeof(XedFieldState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = fields.Length + 1;
            var defs = new FieldDefs(sys.alloc<FieldDef>(count));
            var indexed = defs.Indexed;
            var packed = z32;
            var aligned = z32;
            var i=z8;
            defs[i++] = FieldDef.Empty;
            for(; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i-1);
                var dst = default(FieldDef);
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
                indexed[index] = dst;
                packed += pwidth;
                aligned += awidth;
            }

            defs.SortIndex();
            return defs;
        }
    }
}
