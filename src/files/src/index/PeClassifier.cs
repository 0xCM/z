//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class PeClassifier : IFileClassifier
    {
        static readonly HashSet<FileKind> _Capability= sys.hashset<FileKind>(
            FileKind.Sys,
            FileKind.Obj,
            FileKind.Dll,
            FileKind.Lib,
            FileKind.Exe);
            
        public HashSet<FileKind> Capability => _Capability;

        public FileClass Classify(FilePath src)
        {
            using var file = MemoryFiles.map(src);
            return Classify(file);
        }

        public FileClass Classify(MemoryFile src)
        {
            var @class = FileClass.Empty;
            if(src.FileSize >= 0x3C + 4)
            {
                var sigloc = u32(src.Slice(0x3C,4));
                if(sigloc + 4 <= 1024)
                {
                    var sig = src.Slice(sigloc,4);
                    if((char)skip(sig,0) == 'P' && (char)skip(sig,1) == 'E' && skip(sig,2) == 0 && skip(sig,3) == 0)
                    {
                        @class = new FileClass(src.Path, src.Path.FileKind());
                    }
                }
            }

            return @class;            
        }
    }
}