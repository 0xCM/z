//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct MemberValues
    {

        readonly Index<MemberValue> Data;

        [MethodImpl(Inline)]
        public MemberValues(MemberValue[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref MemberValue this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref MemberValue this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public MemberValue Value(int i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue Value(uint i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue<T> Value<T>(int i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue<T> Value<T>(uint i)
            => Data[i];

        public static implicit operator MemberValues(MemberValue[] src)
            => new (src);
    }
}