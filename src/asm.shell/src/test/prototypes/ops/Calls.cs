//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + calls)]
        public readonly struct Calls
        {
            [Op, Size(18)]
            public static MemoryAddress call(N0 n)
                => target(n);

            [Op, Size(18)]
            public static MemoryAddress call(N1 n)
                => target(n);

            [Op, Size(18)]
            public static MemoryAddress call(N2 n)
                => target(n);

            [Op, Size(18)]
            public static MemoryAddress call(N3 n)
                => target(n);

            [Op, MethodImpl(NotInline)]
            static MemoryAddress target(N0 n)
                => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

            [Op, MethodImpl(NotInline)]
            static MemoryAddress target(N1 n)
                => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

            [Op, MethodImpl(NotInline)]
            static MemoryAddress target(N2 n)
                => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();

            [Op, MethodImpl(NotInline)]
            static MemoryAddress target(N3 n)
                => (MemoryAddress)MethodInfo.GetCurrentMethod().MethodHandle.GetFunctionPointer();
        }
    }

}