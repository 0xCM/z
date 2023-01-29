//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class AssemblyFiles : Seq<AssemblyFiles, AssemblyFile>
    {
        public AssemblyFiles()
        {

        }

        public AssemblyFiles(params AssemblyFile[] src)
            : base(src)
        {

        }

        public static implicit operator AssemblyFiles(AssemblyFile[] src)
            => new AssemblyFiles(src);

        public ReadOnlySeq<AssemblyListEntry> Records()
        {
            var dst = bag<AssemblyListEntry>();
            iter(this, file => {
                dst.Add(new AssemblyListEntry{
                    AssemblyName = file.AssemblyName.SimpleName,
                    Version = file.AssemblyName.Version,
                    Md5Hash = FS.hash(file.Path).FileHash.ContentHash,
                    Path = file.Path
                });
            }, true);
            return dst.Array().Sort();
        }
    }
}