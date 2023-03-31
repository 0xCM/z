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

        [Op]
        public static NativeFunction func(ImageHandle src, string name)
            => new NativeFunction(src, procaddress(src,name), name);

        public static NativeExector<D> exec<D>(ImageHandle src, string name)
            where D : Delegate
                => new NativeExector<D>(src, procaddress(src,name), name, proc<D>(src,name));

        static D proc<D>(ImageHandle src, string name)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(procaddress(src,name), typeof(D));

        [Op]
        public static unsafe Delegate proc(FPtr src, Type t)
            => Marshal.GetDelegateForFunctionPointer(src,t);

        [Op]
        public static Delegate proc(ImageHandle src, Type t, string name)
            => Marshal.GetDelegateForFunctionPointer(procaddress(src, name), t);

        public unsafe static FPtr<D> fptr<D>(NativeModule src, string name)
            where D : Delegate
                => new FPtr<D>(Kernel32.GetProcAddress(src.BaseAddress,name).ToPointer());

        public static unsafe D proc<D>(FPtr src)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(src,typeof(D));

        public static unsafe D proc<D>(MemoryAddress src)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(src,typeof(D));
    }
}