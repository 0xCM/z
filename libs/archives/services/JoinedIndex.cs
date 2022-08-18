//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static JoinedIndex<T> Join<T>(this Index<T> left, Index<T> right)
            => new (left,right);

        [MethodImpl(Inline)]
        public static JoinedIndex<T> Join<T>(this T[] left, T[] right)
            => new (left,right);
    }

    /// <summary>
    /// Defines an allocation-free contiguous presentation of two underlying data sources
    /// </summary>
    public readonly struct JoinedIndex<T>
    {
        public readonly Index<T> Left;

        public readonly Index<T> Right;

        public readonly uint Count;

        readonly int LeftMax;

        readonly int RightMax;

        [MethodImpl(Inline)]
        public JoinedIndex(T[] left, T[] right)
        {
            Left = left;
            Right = right;
            LeftMax = left.Length - 1;
            RightMax = right.Length - 1;
            Count = (uint)(left.Length + right.Length);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsEmpty && Right.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNonEmpty || Right.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        ref T SourceValue(uint i)
        {
            if(i > LeftMax)
                return ref Right[i - Left.Count];
            else
                return ref Left[i];
        }

        [MethodImpl(Inline)]
        ref T SourceValue(int i)
            => ref SourceValue((uint)i);

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref SourceValue(i);
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref SourceValue(i);
        }

        public static JoinedIndex<T> Empty => new (sys.empty<T>(), sys.empty<T>());
    }
}