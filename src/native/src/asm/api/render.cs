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
        public static byte render(AsmHexCode src, Span<char> dst)
            => (byte)HexRender.render(LowerCase, src.Bytes, dst);

        [Op]
        public static uint render(AsmHexCode src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Size;
            var bytes = src.Bytes;
            for(var j=0; j<count; j++)
            {
                HexRender.render(LowerCase, (Hex8)skip(bytes, j), ref i, dst);
                if(j != count - 1)
                    seek(dst, i++) = Chars.Space;
            }
            return i - i0;
        }
    }
}