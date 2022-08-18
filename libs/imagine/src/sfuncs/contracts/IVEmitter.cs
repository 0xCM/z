//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IEmitter128<T> : ISFxEmitter<Vector128<T>>, IFunc128<T>
        where T : unmanaged
    {

    }

    [Free, SFx]
    public interface IEmitter256<T> : ISFxEmitter<Vector256<T>>, IFunc256<T>
        where T : unmanaged
    {

    }
}