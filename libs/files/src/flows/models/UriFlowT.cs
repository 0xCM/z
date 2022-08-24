//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct UriFlow<T> : IFlow<FS.FileUri,FS.FileUri>
        where T : ITool, new()
    {
        public readonly T Actor;

        public readonly FS.FileUri Source;

        public readonly FS.FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(FS.FileUri src, FS.FileUri dst)
        {
            Actor = new();
            Source = src;
            Target = dst;
        }

        FS.FileUri IArrow<FS.FileUri, FS.FileUri>.Source 
            => Source;

        FS.FileUri IArrow<FS.FileUri, FS.FileUri>.Target 
            => Target;

        public static implicit operator UriFlow<T>((FS.FileUri a, FS.FileUri b) src)
            => new UriFlow<T>(src.a, src.b);
    }
}