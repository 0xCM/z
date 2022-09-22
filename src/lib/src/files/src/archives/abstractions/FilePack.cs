//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FilePack : IFilePack
    {
        public readonly FileUri Location;

        public readonly PackageKind PackageKind;

        protected FilePack(FileUri location, PackageKind kind)
        {
            Location = location;
            PackageKind = kind;
        }

        public abstract FileKind FileKind {get;}

        FileUri IFilePack.Location 
            => Location;

        PackageKind IFilePack.PackageKind 
            => PackageKind;
    
        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();
    }
}