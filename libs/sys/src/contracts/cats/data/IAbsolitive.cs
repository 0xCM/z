//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAbsolitive<S>
        where S : IAbsolitive<S>,new()
    {
        S Abs();
    }
}