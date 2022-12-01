//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd(CmdName)]
    public sealed record class SymLink : Command<SymLink>
    {            
        public static SymLink define(FolderPath src, FolderPath dst)
            => new SymLink(SymLink.Flag.Directory, src.ToUri(), dst.ToUri());

        public const string CmdName = "symlink";

        public FileUri Source;

        public FileUri Target;
        
        public Flag Flags;

        public SymLink()
        {
            Source = FileUri.Empty;
            Target = FileUri.Empty;
            Flags = 0;
        }

        [MethodImpl(Inline)]
        public SymLink(Flag flags, FileUri src, FileUri dst)
        {
            Flags = flags;
            Source = src;
            Target = dst;
        }            

        public override string Format()
        {
            var result = EmptyString;
            if(Flags != 0)
            {
                result = $"{CmdName} {Symbols.format(Flags)} {Source} {Target}";
            }
            else
            {
                result = $"{CmdName} {Source} {Target}";
            }
            return result;
        }

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