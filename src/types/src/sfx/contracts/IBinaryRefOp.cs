//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IBinaryRefOp<W,T> : IFuncWT<W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        void Invoke(in T a,  in T b, ref T dst);
    }

    [Free, SFx]
    public interface IBinaryRefStepOp<W,T> : IFuncWT<W,T>
        where T : unmanaged
        where W : unmanaged, ITypeWidth
    {
        void Invoke(int count, int step, in T a, in T b, ref T dst);
    }
}