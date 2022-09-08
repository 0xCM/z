//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public struct RegStore8x64
    {
        ByteBlock64 Storage;

        [MethodImpl(Inline)]
        public ref ulong R(RegIndex index)
            => ref seek64(Storage.Bytes,index);

        public ref ulong this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref seek64(Storage.Bytes,index);
        }

        public ref ulong R0
        {
            [MethodImpl(Inline)]
            get => ref R(0);
        }

        public ref ulong R1
        {
            [MethodImpl(Inline)]
            get => ref R(1);
        }

        public ref ulong R2
        {
            [MethodImpl(Inline)]
            get => ref R(2);
        }

        public ref ulong R3
        {
            [MethodImpl(Inline)]
            get => ref R(3);
        }

        public ref ulong R4
        {
            [MethodImpl(Inline)]
            get => ref R(4);
        }

        public ref ulong R5
        {
            [MethodImpl(Inline)]
            get => ref R(5);
        }

        public ref ulong R6
        {
            [MethodImpl(Inline)]
            get => ref R(6);
        }

        public ref ulong R7
        {
            [MethodImpl(Inline)]
            get => ref R(7);
        }

        public static RegStore8x64 Empty => default;
    }
}