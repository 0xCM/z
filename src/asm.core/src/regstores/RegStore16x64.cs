//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public struct RegStore16x64
    {
        ByteBlock128 Storage;

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

        public ref ulong R8
        {
            [MethodImpl(Inline)]
            get => ref R(8);
        }

        public ref ulong R9
        {
            [MethodImpl(Inline)]
            get => ref R(9);
        }

        public ref ulong R10
        {
            [MethodImpl(Inline)]
            get => ref R(10);
        }

        public ref ulong R11
        {
            [MethodImpl(Inline)]
            get => ref R(11);
        }

        public ref ulong R12
        {
            [MethodImpl(Inline)]
            get => ref R(12);
        }

        public ref ulong R13
        {
            [MethodImpl(Inline)]
            get => ref R(13);
        }

        public ref ulong R14
        {
            [MethodImpl(Inline)]
            get => ref R(14);
        }

        public ref ulong R15
        {
            [MethodImpl(Inline)]
            get => ref R(15);
        }
    }
}