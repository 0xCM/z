//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class TypedFile : ITypedFile
    {
        public FileUri Location {get;}

        readonly IFileType FileType;

        IFileType ITypedFile.FileType 
            => FileType;

        bool INullity.IsEmpty 
            => Location.IsEmpty;

        public string Format()
            => Location.Format();

        protected TypedFile(IFileType type, FileUri location)
        {
            Location = location;
            FileType = type;
        }

        public FileExt Ext => Location.Ext();
    }   
}