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
        public record struct SymLinkCmd : IToolCmd<SymLink,SymLinkCmd>
        {            
            public const string ToolName = N.mklink;

            public FileUri Source;

            public FileUri Target;
            
            public Flag Flags;

            [MethodImpl(Inline)]
            public SymLinkCmd(Flag flags, FileUri src, FileUri dst)
            {
                Flags = flags;
                Source = src;
                Target = dst;
            }            

            public string Format()
            {
                var result = EmptyString;
                if(Flags != 0)
                {
                    result = $"{ToolName} {EnumRender.format(Flags)} {Source} {Target}";
                }
                else
                {
                    result = $"{ToolName} {Source} {Target}";
                }
                return result;
            }

            public override string ToString()
                => Format();

            [SymSource(tools)]
            public enum Flag : byte
            {
                [Symbol("")]
                File,

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