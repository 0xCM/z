//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum PackageKind : byte
    {
        None,

        Zip,

        Nuget,

        Msi
    }

    public interface IFilePack
    {
        FileUri Location {get;}

        PackageKind PackageKind {get;}

        FileKind FileKind {get;}
    }
}