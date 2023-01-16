//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    public class SymHeap
    {                
        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<src.Length; i++)
                counter += sys.skip(src,i).Symbol.CharCount;
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static Pow2x64 next(Pow2x32 src)
            => (Pow2x64)(xmsb((uint)src) << 1);

        [MethodImpl(Inline), Nlz]
        static byte nlz(uint src)
            => (byte)Lzcnt.LeadingZeroCount(src);

        [MethodImpl(Inline), Msb]
        static byte msb(uint src)
            => (byte)(sys.width<uint>(w8) - 1 - nlz(src));

        [MethodImpl(Inline), XMsb]
        static uint xmsb(uint src)
            => Pow2.pow32u(msb(src));

        [Op]
        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)next((Pow2x32)xmsb(dst.SymbolCount));
            dst.CharCount = charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }
         
        [MethodImpl(Inline), Op]
        static Span<char> expr(SymHeap src, uint index)
            => sys.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        public Index<Identifier> Sources;

        public Index<Identifier> Names;

        public Index<char> Expr;

        public Index<uint> ExprLengths;

        public Index<uint> ExprOffsets;

        public Index<SymVal> Values;

        public uint SymbolCount;

        public uint EntryCount;

        public uint CharCount;

        [MethodImpl(Inline), Op]
        public ref Identifier Source(uint index)
            => ref Sources[index];

        [MethodImpl(Inline), Op]
        public ref Identifier Name(uint index)
            => ref Names[index];

        [MethodImpl(Inline), Op]
        public ref uint Offset(uint index)
            => ref ExprOffsets[index];

        [MethodImpl(Inline), Op]
        public ref uint Length(uint index)
            => ref ExprLengths[index];

        [MethodImpl(Inline), Op]
        public uint Size(uint index)
            => Length(index)*2;

        [MethodImpl(Inline), Op]
        public ref SymVal Value(uint index)
            => ref Values[index];

        [MethodImpl(Inline), Op]
        public Span<char> Symbol(uint index)
            => expr(this, index);
    }
}