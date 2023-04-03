//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public unsafe class NtDll
    {
        const string ImageName = "ntdll.dll";
        
        [DllImport(ImageName)]
		public static extern NTSTATUS NtQueryInformationProcess([In] IntPtr ProcessHandle, [In] PROCESSINFOCLASS ProcessInformationClass, [Out] PROCESS_BASIC_INFORMATION* ProcessInformation, uint ProcessInformationLength, out uint ReturnLength);
    }
}