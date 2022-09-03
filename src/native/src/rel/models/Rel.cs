//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using I = Rel;

    /// <summary>
    /// Defines a 32-bit immediate value
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct Rel : IRelOp<uint>
    {
        [MethodImpl(Inline), Op]
        public static RelativeAddress address(MemoryAddress @base, MemoryAddress offset)
            => new RelativeAddress(@base, offset);

        [MethodImpl(Inline)]
        public static RelativeAddress<T> address<T>(MemoryAddress @base, T offset)
            where T : unmanaged, IAddress
                    => new RelativeAddress<T>(@base, offset);

        public readonly uint Value;

        public readonly NativeSize Size;

        [MethodImpl(Inline)]
        public Rel(NativeSize size, uint value)
        {
            Value = value;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public string Format()
            => HexFormatter.format(Size, Value, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Value,(byte)Size);
        }

        uint IValued<uint>.Value
            => Value;

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public MemoryAddress ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel8 src)
            => new Rel(NativeSizeCode.W8, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel16 src)
            => new Rel(NativeSizeCode.W16, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel32 src)
            => new Rel(NativeSizeCode.W32, src.Value);
    }
}