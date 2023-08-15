//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdEffectors : ICmdEffectors
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
            Catalog = ApiServer.catalog(methods);
        }

        public void Dispose()
        {
            Methods.Dispose();
        }

        public bool Handler(ApiCmdRoute route, out ICmdHandler dst)
            => Handlers.Handler(route, out dst);
        
        public bool Method(ApiCmdRoute route, out ApiCmdMethod dst)
            => Methods.Find(route, out dst);
    }
}