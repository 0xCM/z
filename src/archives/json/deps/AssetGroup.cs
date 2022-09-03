//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public record struct AssetGroup
        {
            public string Runtime;

            public Seq<FilePath> AssetPaths;

            public Seq<RuntimeFileInfo> RuntimeFiles;
        }
    }
}