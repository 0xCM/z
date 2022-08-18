//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using FW = PbChecks.Field32.FieldWidth;

    partial class PbChecks
    {
        public struct Field32Source
        {
            [Render(6)]
            public uint Seq;

            [Render(12)]
            public ushort PatternId;

            [Render(12)]
            public ushort InstClass;

            [Render(6)]
            public byte Index;

            [Render(6)]
            public num2 Mode;

            [Render(6)]
            public Hex8 OpCode;

            [Render(6)]
            public BitIndicator Lock;

            [Render(6)]
            public BitIndicator Mod;

            [Render(6)]
            public BitIndicator RexW;

            [Render(6)]
            public BitIndicator Rep;
        }

        [StructLayout(StructLayout,Size=4)]
        public readonly record struct Field32 : IComparable<Field32>
        {
            public uint Data
            {
                [MethodImpl(Inline)]
                get => u32(this);
            }

            public int CompareTo(Field32 src)
                => Data.CompareTo(src.Data);

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(Field32 src)
                => Data == src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint(Field32 src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Field32(uint src)
                => @as<uint,Field32>(src);

            public static Field32 Empty => default;

            public enum FieldName : byte
            {
                Rep = 0,

                Rex = 1,

                Lock = 2,

                Mod = 3,

                Hex8 = 4,

                Class = 5,
            }

            public enum FieldWidth : byte
            {
                Rep = num2.Width,

                Rex = num2.Width,

                Lock = num2.Width,

                Mod = num2.Width,

                Hex8 = num8.Width,

                Class = num11.Width,
            }

            public enum FieldOffset : byte
            {
                Rep = 0,

                Rex = FW.Rep + Rep,

                Lock = FW.Rex + Rex,

                Mod = FW.Lock + Lock,

                Byte = FW.Mod + Mod,

                Hex8 = FW.Hex8 + Byte,
            }
        }
    }
}