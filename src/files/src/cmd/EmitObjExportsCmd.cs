//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CommandName)]
    public record class EmitObjExportsCmd : Command<EmitObjExportsCmd>
    {
        public const string CommandName = "obj/exports";

        public FilePath Source;
    }
}
