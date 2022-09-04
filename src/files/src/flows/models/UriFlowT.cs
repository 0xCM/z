//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct UriFlow<T> : IFlow<_FileUri,_FileUri>
        where T : ITool, new()
    {
        public readonly T Actor;

        public readonly _FileUri Source;

        public readonly _FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(_FileUri src, _FileUri dst)
        {
            Actor = new();
            Source = src;
            Target = dst;
        }

        _FileUri IArrow<_FileUri, _FileUri>.Source 
            => Source;

        _FileUri IArrow<_FileUri, _FileUri>.Target 
            => Target;

        public static implicit operator UriFlow<T>((_FileUri a, _FileUri b) src)
            => new UriFlow<T>(src.a, src.b);
    }
}