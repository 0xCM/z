//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [StructLayout(StructLayout,Pack=1)]
    public struct MemorySymbol : IComparable<MemorySymbol>, IEquatable<MemorySymbol>
    {
        [Render(6)]
        public uint Key;

        [Render(12)]
        public Hash32 HashCode;

        [Render(16)]
        public MemoryAddress Address;

        [Render(8)]
        public ByteSize Size;

        [Render(1)]
        public SymExpr Expr;

        [MethodImpl(Inline)]
        public MemorySymbol(uint key, Hash32 hash, MemoryAddress address, ByteSize size, SymExpr expr)
        {
            Key = key;
            HashCode = hash;
            Address = address;
            Size = size;
            Expr = expr;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address.IsEmpty && Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public int CompareTo(MemorySymbol src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(MemorySymbol src)
            => Address.Equals(src.Address);

        public override int GetHashCode()
            => (int)HashCode;

        public static MemorySymbol Empty
        {
            [MethodImpl(Inline)]
            get => new MemorySymbol(0u, 0u, 0u, 0u, SymExpr.Empty);
        }
    }
}