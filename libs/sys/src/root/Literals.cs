//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Root
    {
        /// <summary>
        /// Canonical return value for search operation that returns a nonnegative value upon success
        /// </summary>
        public const int NotFound = -1;

        /// <summary>
        /// Indicates that emitted content should overwrite whatever file content may exist
        /// </summary>
        public const FileWriteMode Overwrite = FileWriteMode.Overwrite;

        /// <summary>
        /// The number of bytes in a page of memory
        /// </summary>
        public const ushort PageSize = 0x1000;

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        public const MethodImplOptions NotInline = MethodImplOptions.NoInlining;

        public const char ListDelimiter = Chars.Comma;

        /// <summary>
        /// The one, the only
        /// </summary>
        public const string EmptyString = "";

        public const LayoutKind StructLayout = LayoutKind.Sequential;
    }
}