//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public record class BuildInfo
        {
            public string SlnId;

            public string ProjectArea;

            public string ProjectKeyword;

            public BuildTargetKind TargetType;

            public string ProjectType;

            public string ProjectRuntimeId;

            public string ProjectConfigName;

            public string ProjectFramework;

            public FolderPath SlnRoot;

            public FolderPath SlnBuildRoot;

            public string ProjectId;

            public FileName ProjectFile;

            public FilePath ProjectPath;

            public FileName ProjectTargetName;

            public FolderPath ProjectBinDir;

            public FolderPath ProjectObjDir;

            public FilePath ProjectTargetPath;
        }
    }
}