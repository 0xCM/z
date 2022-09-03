//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    // From minidumpapiset.h
    // ne-minidumpapiset-minidump_type.md
    // A normal minidump contains just the information
    // necessary to capture stack traces for all of the
    // existing threads in a process.
    //
    // A minidump with data segments includes all of the data
    // sections from loaded modules in order to capture
    // global variable contents.  This can make the dump much
    // larger if many modules have global data.
    //
    // A minidump with full memory includes all of the accessible
    // memory in the process and can be very large.  A minidump
    // with full memory always has the raw memory data at the end
    // of the dump so that the initial structures in the dump can
    // be mapped directly without having to include the raw
    // memory information.
    //
    // Stack and backing store memory can be filtered to remove
    // data unnecessary for stack walking.  This can improve
    // compression of stacks and also deletes data that may
    // be private and should not be stored in a dump.
    // Memory can also be scanned to see what modules are
    // referenced by stack and backing store memory to allow
    // omission of other modules to reduce dump size.
    // In either of these modes the ModuleReferencedByMemory flag
    // is set for all modules referenced before the base
    // module callbacks occur.
    //
    // On some operating systems a list of modules that were
    // recently unloaded is kept in addition to the currently
    // loaded module list.  This information can be saved in
    // the dump if desired.
    //
    // Stack and backing store memory can be scanned for referenced
    // pages in order to pick up data referenced by locals or other
    // stack memory.  This can increase the size of a dump significantly.
    //
    // Module paths may contain undesired information such as user names
    // or other important directory names so they can be stripped.  This
    // option reduces the ability to locate the proper image later
    // and should only be used in certain situations.
    //
    // Complete operating system per-process and per-thread information can
    // be gathered and stored in the dump.
    //
    // The virtual address space can be scanned for various types
    // of memory to be included in the dump.
    //
    // Code which is concerned with potentially private information
    // getting into the minidump can set a flag that automatically
    // modifies all existing and future flags to avoid placing
    // unnecessary data in the dump.  Basic data, such as stack
    // information, will still be included but optional data, such
    // as indirect memory, will not.
    //
    // When doing a full memory dump it's possible to store all
    // of the enumerated memory region descriptive information
    // in a memory information stream.
    //
    // Additional thread information beyond the basic thread
    // structure can be collected if desired.
    //
    // A minidump with code segments includes all of the code
    // and code-related sections from loaded modules in order
    // to capture executable content.
    //
    // MiniDumpWithoutAuxiliaryState turns off any secondary,
    // auxiliary-supported memory gathering.
    //
    // MiniDumpWithFullAuxiliaryState asks any present auxiliary
    // data providers to include all of their state in the dump.
    // The exact set of what is provided depends on the auxiliary.
    // This can be quite large.
    [Flags]
    public enum MinidumpType : ulong
    {
        /// <summary>
        ///
        /// </summary>
        MiniDumpNormal = 0x00000000,

        /// <summary>
        /// Include the data sections from all loaded modules. This results in the inclusion of global variables,
        /// which can make the minidump file significantly larger. For per-module control, use the ModuleWriteDataSeg
        /// enumeration value from MODULE_WRITE_FLAGS.
        /// </summary>
        MiniDumpWithDataSegs = 0x00000001,

        /// <summary>
        ///
        /// </summary>
        MiniDumpWithFullMemory = 0x00000002,

        /// <summary>
        /// Include high-level information about the operating system handles that are active when the minidump is made
        /// </summary>
        MiniDumpWithHandleData = 0x00000004,

        /// <summary>
        /// Stack and backing store memory written to the minidump file should be filtered to remove all but the pointer values necessary to reconstruct a stack trace.
        /// </summary>
        MiniDumpFilterMemory = 0x00000008,

        /// <summary>
        /// Stack and backing store memory should be scanned for pointer references to modules
        /// in the module list. If a module is referenced by stack or backing store memory, the ModuleWriteFlags member
        /// of the MINIDUMP_CALLBACK_OUTPUT structure is set to ModuleReferencedByMemory.
        /// </summary>
        MiniDumpScanMemory = 0x00000010,

        /// <summary>
        ///
        /// </summary>
        MiniDumpWithUnloadedModules = 0x00000020,

        /// <summary>
        /// Include pages with data referenced by locals or other stack memory. This option can increase the size of the minidump file significantly
        /// </summary>
        MiniDumpWithIndirectlyReferencedMemory = 0x00000040,

        /// <summary>
        ///
        /// </summary>
        MiniDumpFilterModulePaths = 0x00000080,

        /// <summary>
        /// Include complete per-process and per-thread information from the operating system.
        /// </summary>
        MiniDumpWithProcessThreadData = 0x00000100,

        /// <summary>
        /// Scan the virtual address space for PAGE_READWRITE memory to be include
        /// </summary>
        MiniDumpWithPrivateReadWriteMemory = 0x00000200,

        /// <summary>
        /// Reduce the data that is dumped by eliminating memory regions that are not essential to meet criteria
        /// specified for the dump. This can avoid dumping memory that may contain data that is private to the user.
        /// However, it is not a guarantee that no private information will be present
        /// </summary>
        MiniDumpWithoutOptionalData = 0x00000400,

        /// <summary>
        /// Include all accessible memory in the process. The raw memory data is included at the end, so that the
        /// initial structures can be mapped directly without the raw memory information. This option can result in a very
        /// large file.
        /// </summary>
        MiniDumpWithFullMemoryInfo = 0x00000800,

        /// <summary>
        /// Include thread state information
        /// </summary>
        MiniDumpWithThreadInfo = 0x00001000,

        /// <summary>
        /// Include all code and code-related sections from loaded modules to capture executable content. For per-module control, use the ModuleWriteCodeSegs enumeration value from MODULE_WRITE_FLAGS.
        /// </summary>
        MiniDumpWithCodeSegs = 0x00002000,

        /// <summary>
        ///
        /// </summary>
        MiniDumpWithoutAuxiliaryState = 0x00004000,

        /// <summary>
        /// Requests that auxiliary data providers include their state in the dump image; the state data that is
        /// included is provider dependent. This option can result in a large dump image.
        /// </summary>
        MiniDumpWithFullAuxiliaryState = 0x00008000,

        /// <summary>
        /// Scans the virtual address space for PAGE_WRITECOPY memory to be included.
        /// </summary>
        MiniDumpWithPrivateWriteCopyMemory = 0x00010000,

        /// <summary>
        ///
        /// </summary>
        MiniDumpIgnoreInaccessibleMemory = 0x00020000,

        /// <summary>
        /// Adds security token related data. This will make the "!token" extension work when processing a user-mode dump.
        /// </summary>
        MiniDumpWithTokenInformation = 0x00040000,

        /// <summary>
        /// Adds module header related data
        /// </summary>
        MiniDumpWithModuleHeaders = 0x00080000,

        /// <summary>
        /// Adds filter triage related data
        /// </summary>
        MiniDumpFilterTriage = 0x00100000,

        /// <summary>
        /// Adds AVX crash state context registers
        /// </summary>
        MiniDumpWithAvxXStateContext = 0x00200000,

        /// <summary>
        /// dds Intel Processor Trace related data.
        /// </summary>
        MiniDumpWithIptTrace = 0x00400000,

        /// <summary>
        ///
        /// </summary>
        MiniDumpScanInaccessiblePartialPages = 0x00800000,

        MiniDumpValidTypeFlags = 0x00ffffff,
    }

}