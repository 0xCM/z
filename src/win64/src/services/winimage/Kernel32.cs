//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class WinImage
    {        
        public sealed class Kernel32 : NativeImage<Kernel32>
        {
            public NativeImage LoadLibrary(FilePath path)
                => new (path, Windows.Kernel32.LoadLibrary(path.Format()));

            public static Kernel32 load()
                => load(FS.path("C:/windows/system32/kernel32.dll"));
        }
    }
}
