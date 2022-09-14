//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IJsonSource : IExpr
    {
        JsonText ToJson();

        string IExpr.Format()
            => ToJson().Format();
    }

    [Free]
    public interface IJsonSource<H> : IJsonSource
        where H : IJsonSource<H>, new()
    {

    }
}