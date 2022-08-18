//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x8;

    /// <summary>
    /// Classifies file modules
    /// </summary>
    [Flags]
    public enum FileModuleKind : byte
    {
        Unknown = 0,

        /// <summary>
        /// Classifies a file as a module that lacks an entry point
        /// </summary>
        Dll = P2ᐞ00,

        /// <summary>
        /// Classifies a file as a module that has an entry point
        /// </summary>
        Exe = P2ᐞ01,

        /// <summary>
        /// Classifies a file as static module that exports routines for inclusion in other modules
        /// </summary>
        Lib = P2ᐞ02,

        /// <summary>
        /// Classifies a file as a module that does not require a managed execution context for use
        /// </summary>
        Native = P2ᐞ03,

        /// <summary>
        /// Classifies a file as a module that requires a managed execution context for use
        /// </summary>
        Managed =  P2ᐞ04,

        /// <summary>
        /// Classifies a file as a hybrid module that contains both IL and managed code
        /// </summary>
        Hybrid = P2ᐞ05,

        /// <summary>
        /// Classifies an object file
        /// </summary>
        Obj = P2ᐞ06,

        /// <summary>
        /// Classifies a file as a <see cref='Native'/> <see cref='Dll' />
        /// </summary>
        NativeDll = Native | Dll,

        /// <summary>
        /// Classifies a file as a <see cref='Native'/> <see cref='Exe' />
        /// </summary>
        NativeExe = Native | Exe,

        /// <summary>
        /// Classifies a file as a <see cref='Native'/> <see cref='Lib' />
        /// </summary>
        NativeLib = Native | Lib,

        /// <summary>
        /// Classifies a file as a <see cref='Managed'/> <see cref='Dll' />
        /// </summary>
        ManagedDll = Managed | Dll,

        /// <summary>
        /// Classifies a file as a <see cref='Managed'/> <see cref='Exe' />
        /// </summary>
        ManagedExe = Managed | Exe
    }
}