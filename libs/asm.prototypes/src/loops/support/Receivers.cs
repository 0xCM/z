//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static AsmLoops;

    [ApiHost]
    public unsafe readonly struct LoopReceivers
    {
        [MethodImpl(Inline), Op]
        public static Receiver1 r1(int* pDst0)
            => new Receiver1(pDst0);

        [MethodImpl(Inline), Op]
        public static Receiver1 r1(MemoryAddress dst0)
            => new Receiver1(dst0.Pointer<int>());

        [MethodImpl(Inline), Op]
        public static Receiver2 r2(int* pDst0, int* pDst1)
            => new Receiver2(pDst0, pDst1);

        [MethodImpl(Inline), Op]
        public static Receiver2 r2(MemoryAddress dst0, MemoryAddress dst1)
            => new Receiver2(dst0.Pointer<int>(), dst1.Pointer<int>());

        [MethodImpl(Inline), Op]
        public static Receiver3 r3(int* pDst0, int* pDst1, int* pDst2)
            => new Receiver3(pDst0, pDst1, pDst2);

        [MethodImpl(Inline), Op]
        public static Receiver3 r3(MemoryAddress dst0, MemoryAddress dst1, MemoryAddress dst2)
            => new Receiver3(dst0.Pointer<int>(), dst1.Pointer<int>(), dst2.Pointer<int>());
    }
}