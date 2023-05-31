//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SymHeap
    {                
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