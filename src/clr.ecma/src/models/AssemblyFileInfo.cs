//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct AssemblyFileInfo
    {
        [Render(12)]
        public EcmaToken Index;

        [Render(22)]
        public bool ContainsMetadata;

        [Render(48)]
        public BinaryCode Hash;

        [Render(1)]
        public FileUri Name;
    }
}