//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileClassifier
    {
        HashSet<FileKind> Capability {get;}

        FileClass Classify(FilePath src);        

        FileClass Classify(MemoryFile src);
    }
}