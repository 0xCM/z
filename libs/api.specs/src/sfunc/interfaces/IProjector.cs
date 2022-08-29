//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IProjector<S,T>
    {
        T Invoke(in S src);

        void Invoke(in S src, out T dst)
            => dst = Invoke(src);
    }
}