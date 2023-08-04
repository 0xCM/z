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
    }
}