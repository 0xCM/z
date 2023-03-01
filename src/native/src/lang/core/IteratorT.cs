//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static sys;

    public ref struct Iterator<T>
    {
        readonly ReadOnlySpan<T> Source;

        uint Pos;

        readonly uint Count;

        public Iterator(ReadOnlySpan<T> src)
        {
            Source = src;
            Pos = 0;
            Count = (uint)src.Length;
        }

        public bool Next(out T dst)
        {
            if(Pos < Count)   
            {
                dst = skip(Source,Pos++);
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