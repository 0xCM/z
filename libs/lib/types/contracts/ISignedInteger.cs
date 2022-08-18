//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

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