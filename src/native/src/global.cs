//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
global using static global.sys;
global using static global.native;
namespace global
{
    using static Z0.sys;

    [ApiComplete(ApiName)]
    public partial class native
    {
        public const string ApiName = globals + dot + nameof(native);

        public static string format(in EncodingOffsets src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = Z0.text.emitter();
            dst.Append(Chars.LBrace);
            dst.AppendFormat("{0}={1}", "opcode", src.OpCode);
            if(src.ModRm > 0)
                dst.AppendFormat(", {0}={1}", "modrm", src.ModRm);
            if(src.Sib > 0)
                dst.AppendFormat(", {0}={1}", "sib",  src.Sib);
            if(src.Disp > 0)
                dst.AppendFormat(", {0}={1}", "disp", src.Disp);
            if(src.Imm0 > 0)
                dst.AppendFormat(", {0}={1}", "imm0", src.Imm0);
            if(src.Imm1 > 0)
                dst.AppendFormat(", {0}={1}", "imm1", src.Imm1);
            dst.Append(Chars.RBrace);
            return dst.Emit();
        }

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
        {
            var buffer = ByteBlock16.Empty;
            var result = Hex.parse(src, buffer.Bytes);
            if(result)
            {
                var size = Demand.lteq((byte)result.Data,(byte)15);
                var data = slice(buffer.Bytes,0,size);
                buffer[15] = size;
                dst = new AsmHexCode(@as<ByteBlock16,Cell128>(buffer));
            }
            else
                dst = AsmHexCode.Empty;
            return result;
        }

        [Op]
        public static byte render(AsmHexCode src, Span<char> dst)
            => (byte)HexRender.render(LowerCase, src.Bytes, dst);

        [Op]
        public static string format(in AsmHexCode src)
        {
            Span<char> dst = stackalloc char[64];
            var count = render(src,dst);
            return @string(slice(dst,0, count));
        }

        [Op]
        public static AsmHexCode asmhex(string src)
        {
            var dst = AsmHexCode.Empty;
            parse(src.Trim(), out dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint bitstring(AsmHexCode src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
        }

        [Op]
        public static string bitstring(AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            Storage.chars(n256, out var block);
            var dst = block.Data;
            var count = bitstring(src, dst);
            if(count == 0)
                return EmptyString;

            return @string(slice(dst, 0, count));
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode asmhex(ReadOnlySpan<byte> src)
        {
            var cell = Cells.alloc(w128);
            var count = (byte)min(src.Length, 15);
            var dst = bytes(cell);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            BitNumbers.cell8(cell, 15) = count;
            return new AsmHexCode(cell);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode asmhex(ulong src)
        {
            var size = Z0.bits.effsize(src);
            var data = slice(bytes(src), 0, size);
            var storage = 0ul;
            var buffer = bytes(storage);
            reverse(data, buffer);
            return new AsmHexCode(Cells.cell128(u64(first(buffer)), (ulong)size << 56));
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> encoded(AsmHexCode src)
            => slice(src.Bytes, 0, src.Size);

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