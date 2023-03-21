//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct EcmaAssemblyRef
    {
        [Render(12)]
        public BinaryCode Token;

        [Render(48)]
        public @string Name;

        [Render(16)]
        public AssemblyVersion Version;

        [Render(16)]
        public @string Culture;
        
        [Render(24)]
        public BinaryCode Hash;

        [Render(1)]
        public AssemblyFlags Flags;
    }
}