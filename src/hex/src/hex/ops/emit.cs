//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct HexLine
    {
        public const string HexPackPattern = "x{0:x}[{1:D5}:{2:D5}]=<{3}>";
    }

    partial class XHex
    {
        [MethodImpl(Inline)]
        internal static uint Max(this uint[] src)
        {
            var result = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref seek(src,i);
                if(x > result)
                    result = x;
            }
            return result;
        }
    }

    partial struct Hex
    {
        [Op]
        public static ByteSize emit(Index<MemorySegment> src, StreamWriter dst)
        {
            var buffer = sys.span<char>(src.Select(x => (uint)x.Size).Storage.Max()*2);
            var total = 0u;
            for(var i=0u; i<src.Count;i++)
            {
                buffer.Clear();
                ref readonly var seg = ref src[i];
                var charcount = Hex.pack(seg.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)seg.Size;
                dst.WriteLine(string.Format(HexLine.HexPackPattern, seg.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }

        [Op]
        public static ByteSize emit(MemorySegment src, uint bpl, StreamWriter dst)
        {
            var div = src.Length/bpl;
            var mod = src.Length % bpl;
            var count = div + (mod != 0 ? 1 : 0);
            var buffer = sys.alloc<MemorySegment>(count);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            for(var i=0; i<div; i++)
            {
                seek(buffer,i) = new MemorySegment(@base + offset, bpl);
                offset += bpl;
            }
            if(mod !=0)
                seek(buffer, div) = new MemorySegment(@base + offset, mod);
            return emit(buffer, dst);
        }
    }
}