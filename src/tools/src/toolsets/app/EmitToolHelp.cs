//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        public struct EmitToolHelp
        {
            public Actor ToolId;

            public asci32 HelpKind;

            public FilePath Target;

            //public ToolCmdArgs Args;
        }
    }
}