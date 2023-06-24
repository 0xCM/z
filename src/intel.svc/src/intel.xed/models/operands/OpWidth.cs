//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct OpWidth : IComparable<OpWidth>
        {
            public readonly XedWidthCode Code;

            public readonly ushort Bits;

            [MethodImpl(Inline)]
            public OpWidth(XedWidthCode code, ushort bits)
            {
                Code = code;
                Bits = bits;
            }

            [MethodImpl(Inline)]
            public OpWidth(ushort bits)
            {
                Code = 0;
                Bits = bits;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Code !=0 || Bits !=0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Code == 0 && Bits == 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(OpWidth src)
                => ((byte)Code).CompareTo((byte)src.Code);

            [MethodImpl(Inline)]
            public static explicit operator uint(OpWidth src)
                => core.u32(src);

            public static OpWidth Empty => new OpWidth(0);
        }
    }
}