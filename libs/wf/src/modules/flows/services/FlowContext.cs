//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FlowContext
    {
        [MethodImpl(Inline), Op]
        public static FileFlowContext create(IProjectWorkspace src)
            => new FileFlowContext(src, FlowCatalogs.load(src));
    }
}