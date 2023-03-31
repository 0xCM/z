//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct BitChars<T>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        public BitChars(T data)
        {
            Data = data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => size<T>();
        }
    }
}