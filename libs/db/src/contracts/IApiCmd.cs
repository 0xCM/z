//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmd<T> : ICmd<T>, IEquatable<T>
        where T : IApiCmd<T>, new()
    {

    }
}