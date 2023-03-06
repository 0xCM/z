namespace Z0
{
    partial class Build
    {
        /// Internals borrowed from:
        /// https://github.com/dotnet/roslyn/blob/main/src/Workspaces/Core/MSBuild/MSBuild/ProjectFile/ProjectFileInfo.cs
        /// <summary>
        /// Provides information about a project that has been loaded from disk and
        /// built with MSBuild. If the project is multi-targeting, this represents
        /// the information from a single target framework.
        /// </summary>
        public sealed class ProjectFileInfo
        {
            public bool IsEmpty;

            /// <summary>
            /// The language of this project.
            /// </summary>
            public string Language;

            /// <summary>
            /// The path to the project file for this project.
            /// </summary>
            public FilePath FilePath;

            /// <summary>
            /// The path to the output file this project generates.
            /// </summary>
            public FilePath OutputFilePath;

            /// <summary>
            /// The path to the reference assembly output file this project generates.
            /// </summary>
            public FilePath OutputRefFilePath;

            /// <summary>
            /// The default namespace of the project ("" if not defined, which means global namespace),
            /// or null if it is unknown or not applicable. 
            /// </summary>
            /// <remarks>
            /// Right now VB doesn't have the concept of "default namespace". But we conjure one in workspace 
            /// by assigning the value of the project's root namespace to it. So various feature can choose to 
            /// use it for their own purpose.
            /// In the future, we might consider officially exposing "default namespace" for VB project 
            /// (e.g. through a "defaultnamespace" msbuild property)
            /// </remarks>
            public string DefaultNamespace;

            /// <summary>
            /// The target framework of this project.
            /// This takes the form of the 'short name' form used by NuGet (e.g. net46, netcoreapp2.0, etc.)
            /// </summary>
            public string TargetFramework;

            /// <summary>
            /// The command line args used to compile the project.
            /// </summary>
            public ReadOnlySeq<string> CommandLineArgs;

            /// <summary>
            /// The source documents.
            /// </summary>
            public ReadOnlySeq<DocumentFileInfo> Documents;

            /// <summary>
            /// The additional documents.
            /// </summary>
            public ReadOnlySeq<DocumentFileInfo> AdditionalDocuments;

            /// <summary>
            /// The analyzer config documents.
            /// </summary>
            public ReadOnlySeq<DocumentFileInfo> AnalyzerConfigDocuments;

            /// <summary>
            /// References to other projects.
            /// </summary>
            public ReadOnlySeq<ProjectFileReference> ProjectReferences;

            public override string ToString() =>
                string.IsNullOrWhiteSpace(TargetFramework)
                    ? FilePath.Format()
                    : $"{FilePath} ({TargetFramework})";

            private ProjectFileInfo(
                bool isEmpty,
                string language,
                FilePath filePath,
                FilePath outputFilePath,
                FilePath outputRefFilePath,
                string defaultNamespace,
                string targetFramework,
                ReadOnlySeq<string> commandLineArgs,
                ReadOnlySeq<DocumentFileInfo> documents,
                ReadOnlySeq<DocumentFileInfo> additionalDocuments,
                ReadOnlySeq<DocumentFileInfo> analyzerConfigDocuments,
                ReadOnlySeq<ProjectFileReference> projectReferences)
            {
                IsEmpty = isEmpty;
                Language = language;
                FilePath = filePath;
                OutputFilePath = outputFilePath;
                OutputRefFilePath = outputRefFilePath;
                DefaultNamespace = defaultNamespace;
                TargetFramework = targetFramework;
                CommandLineArgs = commandLineArgs;
                Documents = documents;
                AdditionalDocuments = additionalDocuments;
                AnalyzerConfigDocuments = analyzerConfigDocuments;
                ProjectReferences = projectReferences;
            }

            public static ProjectFileInfo Create(
                string language,
                FilePath filePath,
                FilePath outputFilePath,
                FilePath outputRefFilePath,
                string defaultNamespace,
                string targetFramework,
                ReadOnlySeq<string> commandLineArgs,
                ReadOnlySeq<DocumentFileInfo> documents,
                ReadOnlySeq<DocumentFileInfo> additionalDocuments,
                ReadOnlySeq<DocumentFileInfo> analyzerConfigDocuments,
                ReadOnlySeq<ProjectFileReference> projectReferences)
                => new(
                    isEmpty: false,
                    language,
                    filePath,
                    outputFilePath,
                    outputRefFilePath,
                    defaultNamespace,
                    targetFramework,
                    commandLineArgs,
                    documents,
                    additionalDocuments,
                    analyzerConfigDocuments,
                    projectReferences);

            public static ProjectFileInfo CreateEmpty(string language, FilePath filePath)
                => new(
                    isEmpty: true,
                    language,
                    filePath,
                    outputFilePath: null!,
                    outputRefFilePath: null!,
                    defaultNamespace: null!,
                    targetFramework: null!,
                    commandLineArgs: ReadOnlySeq<string>.Empty,
                    documents: ReadOnlySeq<DocumentFileInfo>.Empty,
                    additionalDocuments: ReadOnlySeq<DocumentFileInfo>.Empty,
                    analyzerConfigDocuments: ReadOnlySeq<DocumentFileInfo>.Empty,
                    projectReferences: ReadOnlySeq<ProjectFileReference>.Empty);
        }
    }
}