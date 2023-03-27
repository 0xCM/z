//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        [Record(TableName)]
        public record struct Library
        {
            const string TableName = "jsondeps.libs";

            public string Name;

            public string Version;

            public string Type;

            public string Hash;

            public Seq<LibDep> Dependencies;

            public bool Serviceable;

            public FilePath Path;

            public string HashPath;

            public string RuntimeStoreManifestName;

            public Seq<string> Assemblies;

            public Seq<FilePath> ReferencePaths;
        }
    }
}