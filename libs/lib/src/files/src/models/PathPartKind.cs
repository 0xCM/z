//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x32;

    partial struct FS
    {
        /// <summary>
        /// Classifies <see cref='FilePathPart'/> components
        /// </summary>
        [Flags, SymSource("files")]
        public enum PathPartKind : uint
        {
            None = 0,

            /// <summary>
            /// The filename without the extension
            /// </summary>
            FileName = P2ᐞ00,

            /// <summary>
            /// The '.' delimiter between the filename and the extension
            /// </summary>
            ExtSep = P2ᐞ01,

            /// <summary>
            /// The file extension as determined by the character sequence that follows the <see cref='ExtSep'/>
            /// </summary>
            Ext = P2ᐞ02,

            /// <summary>
            /// A folder name
            /// </summary>
            FolderName,

            /// <summary>
            /// A drive letter
            /// </summary>
            Drive,
        }
    }
}