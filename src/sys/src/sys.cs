//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class sys : sys<sys>
    {
        const NumericKind Closure = Integers;

        const string EmptyString = "";

        internal const MethodImplOptions Options = MethodImplOptions.AggressiveInlining;


        public static Assembly CallingAssembly
        {
            [MethodImpl(Options), Op]
            get => Assembly.GetEntryAssembly();
        }        

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