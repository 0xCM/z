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
            dst.Handle = ImageHandle.own(Kernel32.LoadLibrary(path.Format(PathSeparator.BS)));
            Require.invariant(dst.Handle.IsNonEmpty);
            dst.Path = path;
            dst.OnImageLoad(dst.Handle);
            return dst;
        }

        public static I load(FilePath path, Func<FilePath,ImageHandle> loader)
        {
            var dst = new I();
            Require.invariant(path.Exists);
            dst.Path = path;
            dst.Handle = loader(path);
            dst.OnImageLoad(dst.Handle);
            return dst;
        }

        protected NativeImage()
        {

        }

        protected virtual void OnImageLoad(ImageHandle handle)
        {

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
        public NativeExport Export(string name)
            => NativeModules.export(Handle, name);

        [MethodImpl(Inline)]
        public MemoryAddress ProcAddress(string name)
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