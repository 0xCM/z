//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmHexCode asmhex(ReadOnlySpan<byte> src)
        {
            var cell = Cells.alloc(w128);
            var size = (byte)min(src.Length, 15);
            var dst = bytes(cell);
            for(var i=0; i<size; i++)
                seek(dst,i) = skip(src,i);            
            var code = new AsmHexCode(cell);
            code.Size = size;
            return code;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode asmhex(ulong src)
        {
            var size = bits.effsize(src);
            var data = slice(bytes(src), 0, size);
            var storage = 0ul;
            var buffer = bytes(storage);
            sys.reverse(data, buffer);
            return new AsmHexCode(Cells.cell128(u64(first(buffer)), (ulong)size << 56));
        }

        [Op]
        public static AsmHexCode asmhex(string src)
        {
            var dst = AsmHexCode.Empty;
            parse(src.Trim(), out dst);
            return dst;
        }
    }
}