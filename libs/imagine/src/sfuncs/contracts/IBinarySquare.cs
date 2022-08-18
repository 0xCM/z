//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBinarySquare<W,T> : IBinaryRefOp<W,T>, IBinaryRefStepOp<W,T>
        where T : unmanaged
        where W : unmanaged, ITypeWidth
    {
    }
}