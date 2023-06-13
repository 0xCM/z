//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct AllocToken : IComparable<AllocToken>
    {
        public readonly MemoryAddress Base;

        public readonly Hex32 Offset;

        public readonly Size32 Size;

        [MethodImpl(Inline)]
        public AllocToken(MemoryAddress @base, uint offset, uint size)
        {
            Base = @base;
            Offset = offset;
            Size = size;
        }

        public MemorySeg Segment
        {
            [MethodImpl(Inline)]
            get => new (Base + Offset, Size);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Segment.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(AllocToken src)
            => Base.CompareTo(src.Base);

        [MethodImpl(Inline)]
        public static bool operator < (AllocToken a, AllocToken b)
            => a.Base < b.Base;

        [MethodImpl(Inline)]
        public static bool operator > (AllocToken a, AllocToken b)
            => a.Base > b.Base;

        [MethodImpl(Inline)]
        public static bool operator <= (AllocToken a, AllocToken b)
            => a.Base <= b.Base;

        [MethodImpl(Inline)]
        public static bool operator >= (AllocToken a, AllocToken b)
            => a.Base >= b.Base;

        public static AllocToken Empty => default;
    }
}