//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaRecord
    {
    }

    public interface IEcmaRecord<T> : IEcmaRecord
        where T : unmanaged, IEcmaRecord<T>
    {
    }
}