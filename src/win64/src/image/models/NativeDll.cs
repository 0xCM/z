//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe class NativeDll : NativeImage<NativeDll>
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/windows/win32/dlls/dllmain
        /// </summary>
        readonly public delegate* unmanaged[Stdcall]<IntPtr, uint, IntPtr, uint> MainDelegate;

        public NativeDll()
        {

        }
        public NativeDll(FilePath path, ImageHandle handle)
            : base(path,handle)
        {
            MainDelegate = (delegate* unmanaged[Stdcall]<IntPtr, uint, IntPtr, uint>)GetExport("DllMain").Address.Pointer();
        }

        public MemoryAddress MainAddress => MainDelegate;

        // [MethodImpl(Inline)]
        // public bool Main(uint reason)
        //     => MainDelegate(this, reason, IntPtr.Zero) == 1;
    }
}