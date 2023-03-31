//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CommandName)]
    public record class EmitObjSymbolsCmd : Command<EmitObjSymbolsCmd>
    {
        public const string CommandName = "obj/symbols";

        public FilePath Source;
    }    
}
