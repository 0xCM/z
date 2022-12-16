//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class Package : IFilePackage
    {
        public readonly FileUri Location;

        public readonly PackageKind PackageKind;

        protected Package(FileUri location, PackageKind kind)
        {
            Location = location;
            PackageKind = kind;
        }

        FileUri IFilePackage.Location 
            => Location;

        PackageKind IFilePackage.PackageKind 
            => PackageKind;
    
        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();
    }
}