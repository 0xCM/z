// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [NativeModule(LibName)]
    public readonly partial struct AdvApi
    {
        const string LibName = "advapi32.dll";

        /// <summary>Opens the access token associated with a process.</summary>
        /// <param name="processHandle">
        ///     A handle to the process whose access token is opened. The process must have the
        ///     PROCESS_QUERY_INFORMATION access permission.
        /// </param>
        /// <param name="desiredAccess">
        ///     Specifies an access mask that specifies the requested types of access to the access token.
        ///     These requested access types are compared with the discretionary access control list (DACL) of the token to
        ///     determine which accesses are granted or denied.
        ///     Common specific rights are defined in <seealso cref="TokenAccessRights"/>.
        /// </param>
        /// <param name="tokenHandle">A handle that identifies the newly opened access token when the function returns.</param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(LibName, SetLastError = true)]
        public static extern bool OpenProcessToken(IntPtr processHandle, TokenAccessLevels desiredAccess, out IntPtr processToken);

        [DllImport(LibName, SetLastError = true)]
        public static extern int AdjustTokenPrivileges(IntPtr tokenHandle, bool disableAllPrivleges, ref TOKEN_PRIVILEGES newState, uint bufferLength, out TOKEN_PRIVILEGES previousState, out uint returnLength);

        [DllImport(LibName, SetLastError = true)]
        public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

        public static bool EnableDisablePrivilege(string PrivilegeName, bool enable)
        {
            if (!AdvApi.OpenProcessToken(Process.GetCurrentProcess().Handle, TokenAccessLevels.AdjustPrivileges | TokenAccessLevels.Query, out IntPtr processToken))
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            var tokenPrivleges = new TOKEN_PRIVILEGES { PrivilegeCount = 1, Privileges = new LUID_AND_ATTRIBUTES[1] };

            if (!AdvApi.LookupPrivilegeValue(lpSystemName: null, PrivilegeName, out LUID luid))
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            tokenPrivleges.Privileges[0].LUID = luid;
            tokenPrivleges.Privileges[0].Attributes = enable ? LuidAttributes.Enabled : LuidAttributes.Disabled;
            if (AdvApi.AdjustTokenPrivileges(processToken, disableAllPrivleges: false, ref tokenPrivleges, bufferLength: (uint)Marshal.SizeOf(typeof(TOKEN_PRIVILEGES)), out _, out _) == 0)
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            int returnCode = Marshal.GetLastWin32Error();
            return returnCode != ERROR_NOT_ALL_ASSIGNED;
        }

        const int ERROR_NOT_ALL_ASSIGNED = 1300;
    }
}