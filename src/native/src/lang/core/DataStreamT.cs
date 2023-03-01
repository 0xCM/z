//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static sys;

    public ref struct DataStream<T>
        where T : unmanaged
    {
        readonly ReadOnlySpan<T> Source;

        uint Index;

        readonly uint Length;

        public DataStream(ReadOnlySpan<T> src, uint pos = 0)
        {
            Source = src;
            Index = pos;
            Length = (uint)src.Length;
        }

        [MethodImpl(Inline)]
        public bool Next(out T dst)
        {
            if(Index < Length)   
            {
                dst = skip(Source,Index++);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}