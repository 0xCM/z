//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct Library
        {
            public string Type;

            public string Name;

            public string Version;

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