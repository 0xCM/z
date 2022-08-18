// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    [Flags]
    public enum PageProtection : uint
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// </summary>
        NoAccess = 0x01,

        /// <summary>
        /// Enables read-only access to the committed region of pages
        /// </summary>
        Readonly = 0x02,

        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// </summary>
        ReadWrite = 0x04,

        WriteCopy = 0x08,

        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to write to the committed region results in
        /// an access violation. This flag is not supported by the CreateFileMapping function.
        /// </summary>
        Execute = 0x10,

        /// <summary>
        /// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region
        /// results in an access violation. Windows Server 2003 and Windows XP: This attribute is not supported by the CreateFileMapping
        /// function until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        ExecuteRead = 0x20,

        ExecuteReadWrite = 0x40,

        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object.
        /// An attempt to write to a committed copy-on-write page results in a private copy of the page being
        /// made for the process. The private page is marked as PAGE_EXECUTE_READWRITE, and the change is
        /// written to the new page. This flag is not supported by the VirtualAlloc or VirtualAllocEx functions
        /// </summary>
        ExecuteWriteCopy = 0x80,

        /// <summary>
        /// Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm.
        /// </summary>
        Guard = 0x100,

        /// <summary>
        /// Sets all pages to be non-cachable.
        /// </summary>
        NoCahe = 0x200,

        WriteCombine = 0x400,
    }
}