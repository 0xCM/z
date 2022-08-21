//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class UriFlow  : IFlow<FS.FileUri,FS.FileUri>
    {
        public readonly FS.FileUri Source;

        public readonly FS.FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(FS.FileUri src, FS.FileUri dst)
        {
            Source = src;
            Target = dst;
        }

        FS.FileUri IArrow<FS.FileUri, FS.FileUri>.Source 
            => Source;

        FS.FileUri IArrow<FS.FileUri, FS.FileUri>.Target 
            => Target;
    }
}