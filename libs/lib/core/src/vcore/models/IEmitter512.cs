//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [Free, SFx]
    public interface IEmitter512<T> : ISFxEmitter<Vector512<T>>, IFunc512<T>
        where T : unmanaged
    {

    }
}