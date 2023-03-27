//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public class NativeImage : IDisposable
    {
        public readonly FilePath Path;

        public readonly ImageHandle Handle;

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

        public virtual ReadOnlySeq<INativeOp> Operations 
            => sys.empty<INativeOp>();

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
    }
}