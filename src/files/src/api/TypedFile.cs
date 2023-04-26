//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class TypedFile : ITypedFile
    {
        public FilePath Path {get;}

        readonly IFileType FileType;

        IFileType ITypedFile.FileType 
            => FileType;
    
        bool INullity.IsEmpty 
            => Path.IsEmpty;

        public string Format()
            => Path.Format();

        protected TypedFile(IFileType type)
        {
            Path = FilePath.Empty;
        }

        protected TypedFile(IFileType type, FileUri location)
        {
            Path = location;
            FileType = type;
        }

        public FileExt Ext => Path.Ext;

        public override string ToString()
            => Format();

    }   
}