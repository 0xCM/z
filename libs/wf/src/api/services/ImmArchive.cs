//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ImmArchive : IImmArchive
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ImmArchive(FS.FolderPath src)
        {
            Root = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImmArchive(FS.FolderPath src)
            => new ImmArchive(src);
    }
}