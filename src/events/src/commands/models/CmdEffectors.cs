//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdEffectors : ICmdEffectors
    {
        readonly ApiCmdMethods Methods;

        readonly CmdHandlers Handlers;    

        public readonly ApiCmdCatalog Catalog;

        ApiCmdCatalog ICmdEffectors.Catalog
            => Catalog;

        internal CmdEffectors(ApiCmdMethods methods, CmdHandlers handlers)
        {
            Methods = methods;
            Handlers = handlers;
            Catalog = ApiCmd.catalog(methods);
        }

        public bool Handler(ApiCmdRoute route, out ICmdHandler dst)
            => Handlers.Handler(route, out dst);
        
        public bool Method(ApiCmdRoute route, out ApiCmdMethod dst)
            => Methods.Find(route.Format(), out dst);
    }
}