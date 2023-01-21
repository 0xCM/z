//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    { 
        public static FileName hostfile(ApiHostUri src, FileExt ext)
            => FS.file(string.Format("{0}.{1}", src.Part.Format(), src.HostName), ext);

        public static FileName hostfile(ApiHostUri src, FileKind kind)
            => FS.file(string.Format("{0}.{1}", src.Part.Format(), src.HostName), kind.Ext());
    }
}