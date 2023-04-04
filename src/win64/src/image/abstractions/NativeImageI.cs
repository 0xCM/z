//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Free]
    public unsafe abstract class NativeImage<I> : INativeImage
        where I : NativeImage<I>, new()
    {
        protected ImageHandle Handle;

        ImageHandle INativeImage.Handle
            => Handle;

        public static I load(FilePath path)
        {
            var dst = new I();
            Require.invariant(path.Exists);
            dst.Handle = Kernel32.LoadLibrary(path.Format(PathSeparator.BS));
            Require.invariant(dst.Handle.IsNonEmpty);
            dst.Path = path;
            return dst;
        }

        protected NativeImage()
        {
            Path = FilePath.Empty;            
        }

        protected NativeImage(FilePath path, ImageHandle handle)
        {
            Path = path;
            Handle = handle;
        }
        
        public void Dispose()
        {
            Kernel32.CloseHandle(Handle);
        }

        public FilePath Path {get; private set;}

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Handle;
        }

        [MethodImpl(Inline)]
        public NativeExport GetExport(Label name)
            => NativeModules.export(Handle, name);

        [MethodImpl(Inline)]
        public MemoryAddress GetProcAddress(string name)
            => NativeModules.procaddress(BaseAddress, name);

        [MethodImpl(Inline)]
        public D Proc<D>(string name)
            where D : Delegate
                => NativeModules.proc<D>(BaseAddress, name);
        
        public string Format()
            => $"{BaseAddress}:{Path}";
        
        public override string ToString()
            => Format();
    }
}