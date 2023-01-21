//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class TypedFile<T> : TypedFile, ITypedFile<T>
        where T : IFileType, new()
    {
        public static T FileType => new();

        protected TypedFile()
            : base(FileType)
        {

        }

        protected TypedFile(FilePath location)
            : base(FileType,location)
        {

        }

        T ITypedFile<T>.FileType 
            => FileType;
    }
}