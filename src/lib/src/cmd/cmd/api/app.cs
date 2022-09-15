//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        [Op, MethodImpl(Inline)]
        public static AppCmdSpec app(string name, CmdArgs args)
            => new AppCmdSpec(name, args);
    }
}