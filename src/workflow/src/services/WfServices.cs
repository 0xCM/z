//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfServices : WfSvc<WfServices>, IWfServices
    {

        public JsonDocument Serialize<A>(A src)
            where A : IWfAction<A>, new()
                => JsonData.document(src);

        public A Materialize<A>(JsonText src)
            where A : IWfAction<A>, new()
                => JsonData.materialize<A>(src);
    }
}