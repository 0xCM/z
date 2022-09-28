//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileUriFlow  : IFlow<FileUri,FileUri>
    {
        public readonly FileUri Source;

        public readonly FileUri Target;

        [MethodImpl(Inline)]
        public FileUriFlow(FileUri src, FileUri dst)
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