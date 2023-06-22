//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [ApiComplete]
    public struct AsmOpCodeBits
    {
        const ulong CountSegClear = 0xFF_FF_FF_FF_FF_00_FF_FF;

        ulong Storage;

        [MethodImpl(Inline)]
        public AsmOpCodeBits(ulong src)
        {
            Storage = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Storage == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Storage != 0;
        }

        public byte TokenCount
        {
            [MethodImpl(Inline)]
            get => (byte)((Storage >> 16) & 0xFF);
        }

        [MethodImpl(Inline)]
        public AsmOpCodeBits Include(AsmOcToken src)
        {
            IncTokenCount(out var pos);
            Enable(src.Kind);
            var data = slice(bytes(this),3);
            seek(data, pos) = src.Value;
            return this;
        }

        [MethodImpl(Inline)]
        byte IncTokenCount(out byte pos)
        {
            pos = TokenCount;
            var count = (byte)(pos + 1);
            Storage &= CountSegClear;
            Storage |= ((ulong)count << 16);
            return count;
        }

        [MethodImpl(Inline)]
        void Enable(AsmOcTokenKind kind)
        {
            Storage |= bit.enable((ushort)Storage, (byte)((byte)kind - 1));
        }

        public static AsmOpCodeBits Empty => default;
    }
}