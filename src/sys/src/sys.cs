//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe partial class SysExports
    {
        [UnmanagedCallersOnly(EntryPoint="add")]
        public static uint add(uint a, uint b)
            => sys.add(a,b);


        [UnmanagedCallersOnly(EntryPoint="inc")]
        public static Ptr<ulong> inc(ulong* pSrc)
            => pSrc++;
        
        [UnmanagedCallersOnly(EntryPoint="read")]
        public static uint read(IntPtr hProcess, IntPtr @base, IntPtr buffer, int size)
        {
            var count = 0;
            Windows.Kernel32.ReadProcessMemory(hProcess, @base, buffer, size, out count);                    
            return (uint)count;
        }
    }


    [ApiHost]
    public partial class sys : sys<sys>
    {
        //internal const NumericKind Closure = NumericKind.Integers;

        const string EmptyString = "";

        internal const MethodImplOptions Options = MethodImplOptions.AggressiveInlining;

        //internal const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        public static Process CurrentProcess
        {
            [MethodImpl(Options), Op]
            get => Process.GetCurrentProcess();
        }        

        public static Assembly EntryAssembly
        {
            [MethodImpl(Options), Op]
            get => Assembly.GetCallingAssembly();
        }

        /// <summary>
        /// The handle for the current process
        /// </summary>
        public static IntPtr CurrentProcessHandle
        {
            [MethodImpl(Options), Op]
            get => Process.GetCurrentProcess().Handle;
        }
    }
}