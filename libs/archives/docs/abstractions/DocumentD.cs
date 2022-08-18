//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Document<D> : IDocument<D>
        where D : Document<D>, new()
    {
        public IFsEntry Location {get; protected set;}

        protected Document(IFsEntry src)
        {
            Location = src;
        }

        protected Document()
        {
            Location = FS.FsEntry.Empty;
        }

        public abstract D Load();

        public abstract string Format();
    }
}