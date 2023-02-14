//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class TypedFile<F,T> : TypedFile<T>
        where F : TypedFile<F,T>, new()
        where T : IFileType, new()
    {
        protected TypedFile()
        {

        }   

        protected TypedFile(FilePath path)     
            : base(path)
        {

        }

        public static F Empty => new();
    }
}