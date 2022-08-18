//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly ref struct RowVector256<T>
        where T : unmanaged
    {
        public readonly SpanBlock256<T> Data;

        [MethodImpl(Inline)]
        public RowVector256(in SpanBlock256<T> src)
            => Data = src;

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.CellCount;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.CellCount;
        }

        public Span<T> Unblocked
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public RowVector256<U> As<U>()
            where U : unmanaged
                => Data.As<U>();

        public string Format()
            => Data.Storage.FormatList();

        [MethodImpl(Inline)]
        public ref RowVector256<T> CopyTo(ref RowVector256<T> dst)
        {
            Unblocked.CopyTo(dst.Unblocked);
            return ref dst;
        }

        public RowVector256<U> Convert<U>()
            where U : unmanaged
              => new RowVector256<U>(SpanBlocks.force<T,U>(Data));

        public RowVector256<T> Replicate()
            => new RowVector256<T>(Data.Replicate());

        public bool Equals(RowVector256<T> rhs)
        {
            var lhsData = Unblocked;
            var rhsData = rhs.Unblocked;
            if(lhsData.Length != rhsData.Length)
                return false;
            for(var i = 0; i<lhsData.Length; i++)
                if(gmath.neq(lhsData[i], rhsData[i]))
                    return false;
            return true;
        }

        public override bool Equals(object rhs)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();


        [MethodImpl(Inline)]
        public static implicit operator RowVector256<T>(in SpanBlock256<T> src)
            =>  new RowVector256<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator SpanBlock256<T>(in RowVector256<T> src)
            =>  src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(in RowVector256<T> src)
            =>  src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(in RowVector256<T> src)
            =>  src.Data;

        [MethodImpl(Inline)]
        public static bool operator == (RowVector256<T> lhs, in RowVector256<T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator != (RowVector256<T> lhs, in RowVector256<T> rhs)
            => !lhs.Equals(rhs);


        [MethodImpl(Inline)]
        public static T operator *(RowVector256<T> lhs, in RowVector256<T> rhs)
            => gmath.dot<T>(lhs.Data, rhs.Data);
    }
}