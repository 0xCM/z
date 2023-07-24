//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct CpuModels
    {
        const NumericKind Closure = UnsignedInts;


        public static FixedStack<T> stack<T>(uint capacity)
            where T : unmanaged
                => new FixedStack<T>(sys.alloc<T>(capacity));

        // public static CpuModel<T> cpu<T>(uint cores)
        //     where T : unmanaged
        //         => new CpuModel<T>(sys.alloc<CpuCore<T>>(cores));
    }
}