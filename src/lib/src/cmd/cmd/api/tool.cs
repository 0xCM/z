//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => CmdArgs.arg(args,index).Value;
    }
}