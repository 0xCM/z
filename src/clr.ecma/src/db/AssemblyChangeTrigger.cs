//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class AssemblyChangeTrigger : IFileChangeTrigger
    {
        public bool Enabled {get;}

        public ReadOnlySeq<FolderPath> Locations {get;}

        public ReadOnlySeq<FileExt> Extensions {get;}

        public ReadOnlySeq<IFileChangeReceiver> Receivers {get;}
    }
}