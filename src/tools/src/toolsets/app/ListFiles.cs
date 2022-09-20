//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ListFiles : CmdReactor<ListFiles,ListFilesCmd,CmdResult>
    {
        protected override CmdResult Run(ListFilesCmd cmd)
            => default;
    }
}