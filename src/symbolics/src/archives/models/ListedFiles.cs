//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListedFiles : SortedSeq<ListedFile>
    {
        public ListedFiles()
        {

        }

        [MethodImpl(Inline)]
        public ListedFiles(ListedFile[] src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public ListedFiles(ReadOnlySeq<ListedFile> src)
            : base(src.Unwrap())
        {

        }

        public override string Format()
            => Archives.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListedFiles(ListedFile[] src)
            => new ListedFiles(src);
    }
}