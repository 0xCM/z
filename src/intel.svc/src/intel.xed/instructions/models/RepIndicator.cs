//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(Width)]
        public readonly record struct RepIndicator : IComparable<RepIndicator>
        {
            public const byte Width = num2.Width;

            readonly num2 Data;

            [MethodImpl(Inline)]
            public RepIndicator(RepPrefix src)
            {
                Data = (byte)src;
            }

            public RepPrefix Kind
            {
                [MethodImpl(Inline)]
                get => (RepPrefix)(byte)Data;
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

            public bool IsNonZero
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            [MethodImpl(Inline)]
            public int CompareTo(RepIndicator src)
                => XedRules.cmp(Kind, src.Kind);

            public string Format()
                => IsEmpty ? EmptyString : XedRender.format(Kind);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RepIndicator(RepPrefix src)
                => new RepIndicator(src);

            [MethodImpl(Inline)]
            public static explicit operator uint2(RepIndicator src)
                => (uint2)(byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator uint(RepIndicator src)
                => (uint)src.Kind;

            public static RepIndicator Empty => default;
        }
    }
}