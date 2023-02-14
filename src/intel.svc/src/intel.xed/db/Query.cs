//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedDb
    {
        public readonly struct Query
        {
            public struct GPR32_B1
            {
                [StructLayout(LayoutKind.Sequential, Pack=1)]
                public struct Row
                {
                    public bit REXB;

                    public uint3 RM;

                    public XedRegId OUTREG;
                }

                public struct Aligned
                {
                    ByteBlock64 Storage;

                    Span<byte> Data
                    {
                        [MethodImpl(Inline)]
                        get => Storage.Bytes;
                    }

                    public Span<Row> Rows
                    {
                        [MethodImpl(Inline)]
                        get => recover<Row>(Data);
                    }

                    public ref Row this[byte i]
                    {
                        [MethodImpl(Inline)]
                        get => ref seek(Rows,i);
                    }

                }

                /// <summary>
                /// 00 | [032:013] | [032:013] | GPR32_B.DEC                      | [08:01] REXB                     | [08:03] RM                       | [16:09] OUTREG
                /// Aligned: 512
                /// Packed:  208
                /// </summary>
                [StructLayout(LayoutKind.Sequential,Pack=1,Size=(int)Size)]
                public struct Packed
                {
                    public const uint Size = 26;

                    public const uint RowWidth = 13;

                    const uint RowMask = 0b1_1111_1111_1111;

                    const uint REXB_Width = 1;

                    const uint REXB_Offset = 0;

                    const uint RM_Width = 3;

                    const uint RM_Offset = REXB_Width - REXB_Offset;

                    const uint OUTREG_Width = 9;

                    const uint OUTREG_Offset = RM_Width - RM_Offset;

                    [MethodImpl(Inline)]
                    static bit IsAligned(byte i)
                        => OffsetWidth(i) % RowWidth == 0;

                    [MethodImpl(Inline)]
                    static uint OffsetWidth(byte i)
                        => RowWidth*i;

                    [MethodImpl(Inline)]
                    static uint MinOffsetSize(byte i)
                        => OffsetWidth(i)/8;

                    [MethodImpl(Inline)]
                    public Row Read(byte i)
                    {
                        var dst = default(Row);
                        var src = @as<ushort>(seek(bytes(this),MinOffsetSize(i)));
                        src |= (ushort)RowMask;
                        dst.REXB = bit.test(src,0);
                        dst.RM = bits.slice(src,1,3);
                        dst.OUTREG = (XedRegId)bits.slice(src, 4, 9);
                        return dst;
                    }
                }
            }
        }
    }
}