namespace Z0
{
    partial class Build
    {
        /// Internals inspired/borrowed from:
        /// https://github.com/dotnet/roslyn/blob/main/src/Workspaces/Core/MSBuild/MSBuild/ProjectFile/ProjectFileReference.cs
        public sealed record ProjectFileReference
        {
            /// <summary>
            /// The path on disk to the other project file. 
            /// This path may be relative to the referencing project's file or an absolute path.
            /// </summary>
            public FilePath Path;

            /// <summary>
            /// The aliases assigned to this reference, if any.
            /// </summary>
            public ReadOnlySeq<string> Aliases;

            public ProjectFileReference(FilePath path, ReadOnlySeq<string> aliases)
            {
                Path = path;
                Aliases = aliases;
            }
        }

    }
}
