//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class UriFlow  : IFlow<_FileUri,_FileUri>
    {
        public readonly _FileUri Source;

        public readonly _FileUri Target;

        [MethodImpl(Inline)]
        public UriFlow(_FileUri src, _FileUri dst)
        {
            Source = src;
            Target = dst;
        }

        _FileUri IArrow<_FileUri, _FileUri>.Source 
            => Source;

        _FileUri IArrow<_FileUri, _FileUri>.Target 
            => Target;
    }
}