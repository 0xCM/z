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

    public interface IFilePackage
    {
        FileUri Location {get;}

        PackageKind PackageKind {get;}
    }
}