//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface ICmdEffectors : IDisposable
{
    bool Handler(ApiCmdRoute route, out ICmdHandler dst);

    bool Method(ApiCmdRoute route, out ApiCmdMethod dst);

    ApiCmdCatalog Catalog {get;}
}
