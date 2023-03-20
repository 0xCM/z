//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class DbCmd : WfAppCmd<DbCmd>
    {

        void CreateDb(CmdArgs args)
        {
            var db = MemDb.open(FS.path(args[0]));
        }
    }
}