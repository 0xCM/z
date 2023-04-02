//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public unsafe class NativeImage : IDisposable
    {
        public readonly ImageHandle Handle;

        public readonly FilePath Path;

        public NativeImage(FilePath path, ImageHandle handle)
        {
            Path = path;
            Handle = handle;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Handle;
        }

        public virtual ReadOnlySeq<INativeFunction> Operations 
            => sys.empty<INativeFunction>();

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

        public void Dispose()
        {
            Kernel32.CloseHandle(Handle);
        }

        [MethodImpl(Inline)]
        public static implicit operator void*(NativeImage src)
            => src.BaseAddress.Pointer();        
 
        [MethodImpl(Inline)]
        public static implicit operator IntPtr(NativeImage src)
            => src.Handle;
    }
}