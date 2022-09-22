//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiMember : IApiMethod
    {
        MemoryAddress BaseAddress
            => MemoryAddress.Zero;

        ApiMsil Msil {get;}

        CliSig CliSig {get;}

    }

    [Free]
    public interface IApiMember<T> : IApiMember, IEquatable<T>, IComparable<T>
        where T : IApiMember<T>
    {

    }
}