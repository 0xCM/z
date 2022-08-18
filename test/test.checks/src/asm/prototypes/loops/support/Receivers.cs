//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    using static LoopModels;

    [ApiHost]
    public unsafe readonly struct LoopReceivers
    {
        [MethodImpl(Inline), Op]
        public static Receiver1 create(int* pDst0)
            => new Receiver1(pDst0);

        [MethodImpl(Inline), Op]
        public static Receiver2 create(int* pDst0, int* pDst1)
            => new Receiver2(pDst0, pDst1);

        [MethodImpl(Inline), Op]
        public static Receiver3 create(int* pDst0, int* pDst1, int* pDst2)
            => new Receiver3(pDst0, pDst1, pDst2);

        [MethodImpl(Inline), Op]
        public static Receiver1 create(MemoryAddress dst0)
            => new Receiver1(dst0.Pointer<int>());

        [MethodImpl(Inline), Op]
        public static Receiver2 create(MemoryAddress dst0, MemoryAddress dst1)
            => new Receiver2(dst0.Pointer<int>(), dst1.Pointer<int>());

        [MethodImpl(Inline), Op]
        public static Receiver3 create(MemoryAddress dst0, MemoryAddress dst1, MemoryAddress dst2)
            => new Receiver3(dst0.Pointer<int>(), dst1.Pointer<int>(), dst2.Pointer<int>());
    }
}