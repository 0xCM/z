//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        [Cmd(N.mklink)]
        public struct MkLinkCmd : IToolCmd<MkLink,MkLinkCmd>
        {            
            public FS.FileUri Source;

            public FS.FileUri Target;
            
            public Flag Flags;

            [MethodImpl(Inline)]
            public MkLinkCmd(Flag flags, FS.FileUri src, FS.FileUri dst)
            {
                Flags = flags;
                Source = src;
                Target = dst;
            }

            [SymSource(tools)]
            public enum Flag : byte
            {
                [Symbol("")]
                None,

                [Symbol("D","Creates a directory symbolic link")]
                Directory,

                [Symbol("H","Creates a directory symbolic link")]
                Hard,

                [Symbol("J", "Creates a Directory Junction")]
                Junction,
            }          
        }
    }
}