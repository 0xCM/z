//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;
    
    public abstract class Win64
    {
        [Op]
        public static MemoryAddress procaddress(ImageHandle src, string name)
            => Kernel32.GetProcAddress(src, name);

        public static NativeExector<D> exec<D>(ImageHandle src, string name)
            where D : Delegate
                => new NativeExector<D>(src, procaddress(src,name), name, proc<D>(src,name));

        static D proc<D>(ImageHandle src, string name)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(procaddress(src,name), typeof(D));
    }
}