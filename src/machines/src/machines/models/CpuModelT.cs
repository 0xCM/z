//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CpuModel<T>
        where T : unmanaged
    {
        Index<CpuCore<T>> _Cores;

        [MethodImpl(Inline)]
        internal CpuModel(CpuCore<T>[] cores)
        {
            _Cores = cores;
        }

        [MethodImpl(Inline)]
        public ref CpuCore<T> Core(uint id)
            => ref _Cores[id];
    }
}