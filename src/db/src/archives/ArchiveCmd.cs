//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    class ArchiveCmd : ApiService<ArchiveCmd>
    {
        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Channel, args);
    }
}