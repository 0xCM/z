//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct UriFlow<T> : IFlow<FileUri,FileUri>
        where T : ITool, new()
    {
        public readonly T Actor;

        public readonly FileUri Source;

        public readonly FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(FileUri src, FileUri dst)
        {
            Actor = new();
            Source = src;
            Target = dst;
        }

        FileUri IArrow<FileUri, FileUri>.Source 
            => Source;

        FileUri IArrow<FileUri, FileUri>.Target 
            => Target;

        public static implicit operator UriFlow<T>((FileUri a, FileUri b) src)
            => new UriFlow<T>(src.a, src.b);
    }
}