//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.CodeAnalysis;

    partial class Build
    {
        /// Borrowed and inspired by:
        /// https://github.com/dotnet/roslyn/blob/main/src/Workspaces/Core/MSBuild/MSBuild/ProjectFile/DocumentFileInfo.cs
        /// <summary>
        /// Represents a source file that is part of a project file.
        /// </summary>
        public sealed record DocumentFileInfo
        {
            /// <summary>
            /// The absolute path to the document file on disk.
            /// </summary>
            public FilePath FilePath;

            /// <summary>
            /// A fictional path to the document, relative to the project.
            /// The document may not actually exist at this location, and is used
            /// to represent linked documents. This includes the file name.
            /// </summary>
            public string LogicalPath;

            /// <summary>
            /// True if the document has a logical path that differs from its 
            /// absolute file path.
            /// </summary>
            public bool IsLinked;

            /// <summary>
            /// True if the file was generated during build.
            /// </summary>
            public bool IsGenerated;

            /// <summary>
            /// The <see cref="SourceCodeKind"/> of this document.
            /// </summary>
            public object SourceCodeKind;

            public DocumentFileInfo(FilePath path, string logical, bool linked, bool generated, object kind)
            {
                FilePath = path;
                LogicalPath = logical;
                IsLinked = linked;
                IsGenerated = generated;
                SourceCodeKind = kind;
            }
        }
    }
}