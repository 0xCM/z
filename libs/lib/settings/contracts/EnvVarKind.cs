//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum EnvVarKind : byte
    {
        //
        // Summary:
        //     The environment variable is stored or retrieved from the environment block associated
        //     with the current process.
        [Symbol("process")]
        Process = 0,
        //
        // Summary:
        //     The environment variable is stored or retrieved from the HKEY_CURRENT_USER\Environment
        //     key in the Windows operating system registry. This value should be used on .NET
        //     implementations running on Windows systems only.
        [Symbol("user")]
        User = 1,
        //
        // Summary:
        //     The environment variable is stored or retrieved from the HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session
        //     Manager\Environment key in the Windows operating system registry. This value
        //     should be used on .NET implementations running on Windows systems only.
        [Symbol("machine")]
        Machine = 2
    }
}