//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ApiActorKind;

    public interface ICmdEffectors
    {
        bool Handler(ApiCmdRoute route, out ICmdHandler dst);

        bool Method(ApiCmdRoute route, out ApiCmdMethod dst);

        ApiCmdCatalog Catalog {get;}
    }
}