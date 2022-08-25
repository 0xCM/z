//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ImmArchive : IImmArchive
    {
        public FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ImmArchive(FolderPath src)
        {
            Root = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImmArchive(FolderPath src)
            => new ImmArchive(src);
    }
}