//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(Width)]
        public readonly record struct LockIndicator : IComparable<LockIndicator>
        {
            public const byte Width = num2.Width;

            readonly num2 Data;

            [MethodImpl(Inline)]
            public LockIndicator(num2 data)
            {
                Data = data;
            }

            [MethodImpl(Inline)]
            public LockIndicator(bit lockable, bit locked)
            {
                Data = PolyBits.pack(lockable,locked);
            }

            public bit Lockable
            {
                [MethodImpl(Inline)]
                get => bit.test(Data,0);
            }

            public bit Locked
            {
                [MethodImpl(Inline)]
                get => bit.test(Data,1);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            [MethodImpl(Inline)]
            public int CompareTo(LockIndicator src)
                => new LockSort(this).CompareTo(new LockSort(src));

            public static LockIndicator Empty => default;

            public string Format()
                => IsEmpty ? EmptyString : Locked.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator uint(LockIndicator src)
                => src.Data;

            [MethodImpl(Inline)]
            public static explicit operator LockIndicator(uint src)
                => new LockIndicator((num2)src);

            [MethodImpl(Inline)]
            public static implicit operator LockIndicator(num2 src)
                => new LockIndicator(src);

            [MethodImpl(Inline)]
            public static implicit operator num2(LockIndicator src)
                => src.Data;

        }
    }
}