//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypedFile : IFile<FileUri>
    {        
        IFileType FileType {get;}        
    }

    public interface ITypedFile<T> : ITypedFile
        where T : IFileType, new()
    {
        new T FileType {get;}

        IFileType ITypedFile.FileType
            => FileType;
    }
}