//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Document<D,C> : Document<D>, IDocument<D,C>
        where D : Document<D,C>, new()
    {
        [MethodImpl(Inline)]
        public static D load(C content)
        {
            var doc = new D();
            doc.Content = content;
            return doc;
        }

        public C Content {get; protected set;}

        protected Document(C content)
            : base(FsEntry.Empty)
        {
            Content = content;
        }

        protected Document(IFsEntry src, C content)
            : base(src)
        {
            Content = content;
        }

        [MethodImpl(Inline)]
        D WithContent(C content)
        {
            Content = content;
            return (D)this;
        }

        public virtual D Load(C content)
            => new D().WithContent(content);

        public override string Format()
            => Content.ToString();

        public override string ToString()
            => Format();
    }
}