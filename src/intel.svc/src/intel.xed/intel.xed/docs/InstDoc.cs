//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDocs
    {
        public class InstDoc
        {
            public readonly Index<InstDocPart> Parts;

            public InstDoc(InstDocPart[] src)
            {
                Parts = src.Sort();
            }

            public ref InstDocPart this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public ref InstDocPart this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public string Format()
                => new InstDocFormatter(this).Format();

            public override string ToString()
                => Format();
        }
    }
}