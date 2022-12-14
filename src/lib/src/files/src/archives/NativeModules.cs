//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Windows.Kernel32;

    [ApiHost]
    public readonly partial struct NativeModules
    {
        const string Kernel32 = Windows.Kernel32.LibName;

        [MethodImpl(Inline), Op]
        public static NativeModule kernel32()
            => new NativeModule(Kernel32, LoadLibrary(Kernel32));

        [MethodImpl(Inline), Op]
        public static NativeModule load(FileName src)
            => new NativeModule(Kernel32, LoadLibrary(src.Name));

        [MethodImpl(Inline), Op]
        public static NativeModule load(FilePath src)
            => new NativeModule(src.Name, LoadLibrary(src.Name));

        [MethodImpl(Inline), Op]
        public static DllMainDelegate main(NativeModule src)
            => proc<DllMainDelegate>(src, nameof(OS.Delegates.DllMain));

        [MethodImpl(Inline), Op]
        public static MemoryAddress procaddress(NativeModule src, string name)
            => GetProcAddress(src.Address, name);

        [MethodImpl(Inline), Op]
        public unsafe static FPtr fptr(NativeModule src, string name)
            => new FPtr(GetProcAddress(src.Address,name).ToPointer());

        [MethodImpl(Inline), Op]
        public static unsafe Delegate proc(FPtr src, Type t)
            => Marshal.GetDelegateForFunctionPointer(src,t);

        [MethodImpl(Inline), Op]
        public static NativeFunction func(NativeModule src, string name)
            => new NativeFunction(src, procaddress(src,name), name);

        [MethodImpl(Inline), Op]
        public static NativeFunction<D> func<D>(NativeModule src, string name)
            where D : Delegate
                => new NativeFunction<D>(src, procaddress(src,name), name, proc<D>(src,name));

        [MethodImpl(Inline), Op]
        public static Delegate proc(NativeModule src, Type t, string name)
            => Marshal.GetDelegateForFunctionPointer(procaddress(src,name), t);

        [MethodImpl(Inline)]
        public unsafe static FPtr<D> fptr<D>(NativeModule src, string name)
            where D : Delegate
                => new FPtr<D>(GetProcAddress(src.Address,name).ToPointer());

        [MethodImpl(Inline)]
        public static unsafe D proc<D>(FPtr src)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(src,typeof(D));

        [MethodImpl(Inline)]
        public static D proc<D>(NativeModule src, string name)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(procaddress(src,name), typeof(D));
    }
}