//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline)]
        public unsafe static void map<M,T>(Span<T> src, M mapper, Span<MemoryAddress> dst)
            where T : unmanaged
            where M : IPointedMap<T,MemoryAddress>
        {
            var count = (uint)src.Length;
            fixed(T* pSrc = src)
            {
                var p = pSrc;
                for(var i=0u; i<count; i++)
                    seek(dst,i) = mapper.Map(p++);
            }
        }
    }
}