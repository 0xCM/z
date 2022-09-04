//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    partial class XFs
    {
        public static _FileUri[] ToUri(this Span<FilePath> src)
            => src.Map(x => x.ToUri());

        public static _FileUri[] ToUri(this Index<FilePath> src)
            => src.Map(x => x.ToUri());

        public static _FileUri[] ToUri(this FilePath[] src)
            => src.Map(x => x.ToUri());

        public static _FileUri[] ToUri(this ReadOnlySpan<FilePath> src)
            => src.Map(x => x.ToUri());

        public static _FileUri[] ToUri(this Files src)
            => src.Map(x => x.ToUri());
    }
}