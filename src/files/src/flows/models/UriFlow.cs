//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class UriFlow  : IFlow<FileUri,FileUri>
    {
        public readonly FileUri Source;

        public readonly FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(FileUri src, FileUri dst)
        {
            Source = src;
            Target = dst;
        }

        FileUri IArrow<FileUri, FileUri>.Source 
            => Source;

        FileUri IArrow<FileUri, FileUri>.Target 
            => Target;
    }
}