//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct CpuModels
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CpuCore<T> core<T>(uint id)
            where T : unmanaged
                => new CpuCore<T>(id);

        public static Stack<T> stack<T>(uint capacity)
            where T : unmanaged
                => new Stack<T>(sys.alloc<T>(capacity));

        public static CpuModel<T> cpu<T>(uint cores)
            where T : unmanaged
                => new CpuModel<T>(sys.alloc<CpuCore<T>>(cores));
    }
}