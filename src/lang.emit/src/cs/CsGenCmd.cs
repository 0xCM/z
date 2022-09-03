//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsGenCmd : AppCmdService<CsGenCmd>
    {
        [CmdOp("gen/cs/shim")]
        void GenToolShim(CmdArgs args)
            => ShimGen.gen(ShimGen.bind(args, out _));
    }
}