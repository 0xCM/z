//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using static sys;

    public struct __m64<T>
        where T : unmanaged
    {
        internal Cell64<T> Data;

        [MethodImpl(Inline)]
        public __m64(Cell64<T> src)
            => Data = src;

        public uint Width => 64;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }
    }    
}