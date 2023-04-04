//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AssemblyFiles : Seq<AssemblyFiles, AssemblyFile>
    {
        public readonly IDbArchive Source;

        public AssemblyFiles()
        {

        }

        public AssemblyFiles(IDbArchive archive, params AssemblyFile[] src)
            : base(src)
        {
            Source = archive;
        }
    }
}