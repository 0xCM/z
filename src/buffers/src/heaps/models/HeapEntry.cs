//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct HeapEntry : IDataType<HeapEntry>, IDataString
    {
        [Render(8)]
        public readonly Address32 Offset;

        [Render(8)]
        public readonly uint Size;

        [MethodImpl(Inline)]
        public HeapEntry(Address32 offset, uint length)
        {
            Offset = offset;
            Size = length;
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Offset.Hash | (Hash32)Size;
        }

        public bool Equals(HeapEntry src)
            => Offset == src.Offset && Size == src.Size;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(HeapEntry src)
            => Offset.CompareTo(src.Offset);

        public string Format()
            => $"[{Offset}:{Size}]";

        public override string ToString()
            => Format();
        
        public static HeapEntry Empty => default;
    }
}