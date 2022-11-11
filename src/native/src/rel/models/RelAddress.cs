//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct RelAddress : IDataType<RelAddress>
    {
        public readonly MemoryAddress Base;

        public readonly MemoryAddress Offset;

        [MethodImpl(Inline)]
        public RelAddress(MemoryAddress @base, MemoryAddress offset)
        {
            Base = @base;
            Offset = offset;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Base == 0 && Offset == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Offset.Hash;
        }

        [MethodImpl(Inline)]
        public MemoryAddress Resolve()
            => Base + Offset;

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("[{0x}:{1x}]", (ulong)Base, (ulong)Offset);

        [MethodImpl(Inline)]
        public bool Equals(RelAddress src)
            => Base == src.Base && Offset == src.Offset;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Offset.GetHashCode();

        public override bool Equals(object src)
            => src is RelAddress l && Equals(l);

        [MethodImpl(Inline)]
        public int CompareTo(RelAddress src)
            => Resolve().CompareTo(src.Resolve());
 
        [MethodImpl(Inline)]
        public static RelAddress operator+(RelAddress x, byte y)
            => new RelAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelAddress operator+(RelAddress x, ushort y)
            => new RelAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelAddress operator+(RelAddress x, uint y)
            => new RelAddress(x.Base, x.Offset + y);

        [MethodImpl(Inline)]
        public static RelAddress operator-(RelAddress x, byte y)
            => new RelAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelAddress operator-(RelAddress x, ushort y)
            => new RelAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static RelAddress operator-(RelAddress x, uint y)
            => new RelAddress(x.Base, x.Offset - y);

        [MethodImpl(Inline)]
        public static bool operator==(RelAddress x, RelAddress y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelAddress x, RelAddress y)
            => !x.Equals(y);

        public static RelAddress Empty
            => default;
    }
}