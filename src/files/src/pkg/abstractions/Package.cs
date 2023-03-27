//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class Package : IFilePackage, IComparable<Package>
    {
        [Render(16)]
        public readonly PackageKind PackageKind;

        [Render(1)]
        public readonly FilePath Location;

        protected Package(FilePath location, PackageKind kind)
        {
            Location = location;
            PackageKind = kind;
        }

        FilePath IFilePackage.Location 
            => Location;

        PackageKind IFilePackage.PackageKind 
            => PackageKind;
    
        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();
        
        public int CompareTo(Package src)
            => Location.CompareTo(src.Location);
    }
}