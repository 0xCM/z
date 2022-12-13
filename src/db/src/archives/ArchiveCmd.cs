//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Commands;

    using static sys;

    class ArchiveCmd : ApiService<ArchiveCmd>
    {
        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Wf, args);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel, args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => Archives.copy(Channel, args);

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => Archives.catalog(Channel, args);
    }
}