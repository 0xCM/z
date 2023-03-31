//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Windows.Kernel32;

    public class KnownModules 
    {
        internal const string Kernel32 = Windows.ImageNames.Kernel32;

        [MethodImpl(Inline), Op]
        public static NativeModule kernel32()
            => new NativeModule(Kernel32, LoadLibrary(Kernel32));
    }

    [ApiHost,Free]
    public class NativeModules
    {
        const string Kernel32 = Windows.ImageNames.Kernel32;

        [MethodImpl(Inline), Op]
        public static LoadedModule loaded(string name)
            => new (name, GetModuleHandle(name));

        [MethodImpl(Inline), Op]
        public static NativeModule load(FilePath src)
            => new NativeModule(src.Name, LoadLibrary(src.Name));

        [MethodImpl(Inline), Op]
        public static DllMainDelegate dllmain(NativeModule src)
            => proc<DllMainDelegate>(src, nameof(OS.Delegates.DllMain));

        [MethodImpl(Inline), Op]
        public static MemoryAddress procaddress(NativeModule src, string name)
            => GetProcAddress(src.BaseAddress, name);

        [MethodImpl(Inline), Op]
        public static MemoryAddress procaddress(MemoryAddress @base, string name)
            => GetProcAddress(@base, name);

        [MethodImpl(Inline), Op]
        public static NativeExport export(ImageHandle src, string name)
            => new NativeExport(name, GetProcAddress(src, name));

        [MethodImpl(Inline), Op]
        public unsafe static FPtr fptr(NativeModule src, string name)
            => new FPtr(GetProcAddress(src.BaseAddress, name).ToPointer());

        [MethodImpl(Inline), Op]
        public unsafe static FPtr fptr(NativeExport src)
            => new (src.Address.Pointer());
    
        [MethodImpl(Inline), Op]
        public static unsafe Delegate proc(FPtr src, Type t)
            => Marshal.GetDelegateForFunctionPointer(src,t);

        [MethodImpl(Inline), Op]
        public static Delegate proc(NativeModule src, Type t, string name)
            => Marshal.GetDelegateForFunctionPointer(procaddress(src,name), t);

        [MethodImpl(Inline)]
        public unsafe static FPtr<D> fptr<D>(NativeModule src, string name)
            where D : Delegate
                => new FPtr<D>(GetProcAddress(src.BaseAddress,name).ToPointer());

        [MethodImpl(Inline)]
        public static unsafe D proc<D>(FPtr src)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(src,typeof(D));

        [MethodImpl(Inline)]
        public static unsafe D proc<D>(MemoryAddress src)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(src,typeof(D));

        [MethodImpl(Inline)]
        public static D proc<D>(NativeModule src, string name)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(procaddress(src,name), typeof(D));

        [MethodImpl(Inline)]
        public static D proc<D>(MemoryAddress src, string name)
            where D : Delegate
                => (D)Marshal.GetDelegateForFunctionPointer(procaddress(src,name), typeof(D));
    }
}