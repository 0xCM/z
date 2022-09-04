//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static UriSchemes;

    public abstract record class LocalUri<U> : Uri<U,Local>
        where U : LocalUri<U>,new()
    {

    }
}