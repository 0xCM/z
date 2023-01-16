//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class FileTypes : ReadOnlySeq<FileTypes, IFileType>
    {        
        public FileTypes()
        {

        }

        public FileTypes(HashSet<IFileType> src)
            : base(src.Array())
        {
            
        }               
    }
}