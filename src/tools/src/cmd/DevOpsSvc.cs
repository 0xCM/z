//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DevOpsSvc : WfSvc<DevOpsSvc>
    {
        public DbArchive Control => AppDb.Control();
    }
}