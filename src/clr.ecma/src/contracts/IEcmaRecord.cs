//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaRecord
    {
    }

    public interface IEcmaRow<T> : IEcmaRecord
        where T : unmanaged, IEcmaRow<T>
    {
    }
}