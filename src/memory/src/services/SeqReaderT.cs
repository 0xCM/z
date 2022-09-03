//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public unsafe struct SeqReader<T>
        where T : unmanaged
    {
        T* Current;

        long Count;

        T* Last;

        [MethodImpl(Inline)]
        internal SeqReader(T* pSrc, long count)
        {
            Current = pSrc;
            Count = count;
            Last = gptr(skip(@ref(pSrc), count));
        }

        [MethodImpl(Inline)]
        public ref T Next()
        {
            if(Count != 0)
            {
                ref var result = ref Current;
                Current++;
                Count--;
                return ref @ref(result);
            }
            return ref @ref(Last);
        }

        [MethodImpl(Inline)]
        public ref T NextIndex(out long index)
        {
            index = Count;
            if(Count >= 0)
            {
                ref var result = ref Current;
                Current++;
                Count--;
                return ref @ref(result);
            }
            return ref @ref(Last);
        }

        [MethodImpl(Inline)]
        public bool Next(out T dst)
        {
            if(Count > 0)
            {
                dst = *Current;
                Current++;
                Count--;
                return true;
            }
            dst = default;
            return false;
        }
    }
}