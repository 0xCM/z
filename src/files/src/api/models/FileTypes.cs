//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class FileTypes : ReadOnlySeq<FileTypes, IFileType>
    {        
        public static FileTypes discover(params Assembly[] src)
            => new (src.Types().Tagged<FileTypeAttribute>().Concrete().Map(x => (IFileType)Activator.CreateInstance(x)).ToHashSet());     

        public FileTypes()
        {

        }

        public FileTypes(HashSet<IFileType> src)
            : base(src.Array())
        {
            
        }               
    }
}