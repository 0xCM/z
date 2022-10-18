//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines select MSVS environment variable names
    /// </summary>
    [LiteralProvider]
    public readonly struct MsvsVarNames
    {
        /// <summary>
        /// The system lib include variable, conformed to the msvs command-line environment
        /// </summary>
        public const string INCLUDE = nameof(INCLUDE);

        /// <summary>
        /// The system lib environment variable, conformed to the msvs command-line environment
        /// </summary>
        public const string LIBPATH = nameof(LIBPATH);

        /// <summary>
        /// An alias for <see cref='LIBPATH'/>
        /// </summary>
        public const string LIB = nameof(LIB);

        /// <summary>
        /// E.G., x64-windows-static
        /// </summary>
        public const string VCPKG_DEFAULT_TRIPLET = nameof(VCPKG_DEFAULT_TRIPLET);

        /// <summary>
        /// The msvs installation root
        /// </summary>
        public const string VSINSTALLDIR = nameof(VSINSTALLDIR);

        /// <summary>
        /// {VSINSTALLDIR}\VSSDK
        /// </summary>
        public const string VSSDKINSTALL = nameof(VSSDKINSTALL);

        /// <summary>
        /// The vctools version number
        /// </summary>
        public const string VCToolsVersion = nameof(VCToolsVersion);

        /// <summary>
        /// The vctools installation directory, e.g. of the form {VSINSTALLDIR}\VC\Tools\MSVC\{VCToolsVersion}
        /// </summary>
        public const string VCToolsInstallDir = nameof(VCToolsInstallDir);
    }
}