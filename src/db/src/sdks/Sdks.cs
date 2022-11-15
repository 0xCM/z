//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Sdks
    {
        public static Sdk sdk(FolderPath src) => new(src);

        public sealed class Sdk : Sdk<Sdk,SdkKind>
        {
            public Sdk()
            {

            }

            public Sdk(FolderPath src)
                : base(src)
            {

            }

            public IModuleArchive Modules => Archives.modules(Location);
            
        }
    }
}

//K:\dist\dotnet\coreclr\windows.x64.Release