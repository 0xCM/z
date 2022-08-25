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

            public FS.FolderPath SlnRoot;

            public FS.FolderPath SlnBuildRoot;

            public string ProjectId;

            public FS.FileName ProjectFile;

            public FilePath ProjectPath;

            public FS.FileName ProjectTargetName;

            public FS.FolderPath ProjectBinDir;

            public FS.FolderPath ProjectObjDir;

            public FilePath ProjectTargetPath;
        }
    }
}