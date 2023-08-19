//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct asm
    {
        [Op]
        public static Disp disp(ReadOnlySpan<byte> src, byte pos, NativeSize size)
        {
            var val = Disp.Zero;
            var length = size.Width/8;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    val = new Disp((sbyte)skip(src, pos), size.Code);
                break;
                case NativeSizeCode.W16:
                    val = new Disp(slice(src, pos, length).TakeInt16(), size.Code);
                break;
                case NativeSizeCode.W32:
                    val = new Disp(slice(src, pos, length).TakeInt32(), size.Code);
                break;
                case NativeSizeCode.W64:
                    val = new Disp(slice(src, pos, length).TakeInt64(), size.Code);
                break;
            }

            return val;
        }

        [MethodImpl(Inline)]
        public static Disp8 disp8(sbyte value)
            => new Disp8(value);

        [MethodImpl(Inline)]
        public static Disp16 disp16(short value)
            => new Disp16(value);

        [MethodImpl(Inline)]
        public static Disp32 disp32(int value)
            => new Disp32(value);

        [MethodImpl(Inline)]
        public static Disp32 disp64(int value)
            => new Disp32(value);
    }
}