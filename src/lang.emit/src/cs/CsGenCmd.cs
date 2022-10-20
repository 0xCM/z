//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsGenCmd : WfAppCmd<CsGenCmd>
    {
        [CmdOp("gen/cs/shim")]
        void GenToolShim(CmdArgs args)
            => ShimEmitter.gen(ShimEmitter.bind(args, out _));
    }
}