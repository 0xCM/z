//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FilePack<P> : FilePack
        where P : FilePack<P>
    {
        protected FilePack(FileUri location, PackageKind kind)
            : base(location,kind)
        {
        }
    }
}