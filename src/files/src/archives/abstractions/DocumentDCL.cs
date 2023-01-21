//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Document<D,C,L> : Document<D,C>, IDocument<D,C,L>
        where D : Document<D,C,L>, new()
        where L : IFsEntry
    {
        public static D load(L location)
        {
            var doc = new D();
            doc.Location = location;
            return doc.Load();
        }

        protected Document(L src, C content)
            : base(src, content)
        {
            Location = src;
        }

        protected Document(C content)
            : base(content)
        {
            Location = default;
        }

        public new L Location {get; protected set;}
    }
}