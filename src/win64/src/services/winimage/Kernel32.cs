//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class WinImage
    {
        public sealed class Kernel32 : ImageRef<Kernel32Image>
        {
            class Delegates
            {
                [Free, UnmanagedFunctionPointer(CallingConvention.StdCall)]
                public delegate IntPtr GetProcAddress(IntPtr module, string name);

                [Free, UnmanagedFunctionPointer(CallingConvention.StdCall)]
                public delegate IntPtr LoadLibraryW(string path);
            }

            NativeExector<Delegates.GetProcAddress> GetProcAddressExec;

            NativeExector<Delegates.LoadLibraryW> LoadLibraryExec;

            public Kernel32(Kernel32Image src)
                : base(src)
            {
                GetProcAddressExec = Win64.exec<Delegates.GetProcAddress>(Handle, nameof(Delegates.GetProcAddress));
                LoadLibraryExec = Win64.exec<Delegates.LoadLibraryW>(Handle, nameof(Delegates.LoadLibraryW));
            }

            public MemoryAddress GetProcAddress(string name)
                => GetProcAddressExec.F(Handle, name);

            public ImageHandle LoadLibrary(FilePath path)
            {
                if(!path.Exists)
                    sys.@throw(FS.missing(path));

                return ImageHandle.own(LoadLibraryExec.F(path.Format(PathSeparator.BS)));
            }

            [MethodImpl(Inline)]
            public static implicit operator Kernel32(Kernel32Image src)
                => new Kernel32(src);
        }
        
        public sealed class Kernel32Image : NativeImage<Kernel32Image>
        {
            public static Kernel32Image load()
                => load(FS.dir("c:/windows/system32") + FS.file("kernel32", FileKind.Dll));
            
        }
    }
}
