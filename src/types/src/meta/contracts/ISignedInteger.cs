//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISignedInteger : IScalarValue
    {

    }

    [Free]
    public interface ISignedInteger<T> : ISignedInteger, IScalarValue<T>
        where T : unmanaged
    {
    }
}