//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Package<P> : Package
        where P : Package<P>
    {
        protected Package(FilePath location, PackageKind kind)
            : base(location,kind)
        {
        }
    }
}