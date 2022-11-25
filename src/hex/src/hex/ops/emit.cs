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

    partial struct Hex
    {
        [Op]
        public static ByteSize emit(Index<MemorySeg> src, StreamWriter dst)
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
        public static ByteSize emit(MemorySeg src, uint bpl, StreamWriter dst)
        {
            var div = src.Length/bpl;
            var mod = src.Length % bpl;
            var count = div + (mod != 0 ? 1 : 0);
            var buffer = sys.alloc<MemorySeg>(count);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            for(var i=0; i<div; i++)
            {
                seek(buffer,i) = new MemorySeg(@base + offset, bpl);
                offset += bpl;
            }
            if(mod !=0)
                seek(buffer, div) = new MemorySeg(@base + offset, mod);
            return emit(buffer, dst);
        }
    }
}