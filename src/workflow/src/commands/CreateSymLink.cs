//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    using Windows;

    [Cmd(CmdName)]
    public sealed record class CreateSymLink : Command<CreateSymLink>
    {            
        public const string CmdName = "symlink";

        public FsEntry Source;

        public FsEntry Target;
        
        public bool Overwrite;

        public SymLinkKind Kind;

        public CreateSymLink()
        {
            Source = FsEntry.Empty;
            Target = FsEntry.Empty;
            Overwrite = true;
            Kind = SymLinkKind.Directory;
        }

        [MethodImpl(Inline)]
        public CreateSymLink(FilePath src, FilePath dst, bool overwrite)
        {
            Source = src;
            Target = dst;
            Overwrite = overwrite;
            Kind = SymLinkKind.File;
        }            

        [MethodImpl(Inline)]
        public CreateSymLink(FolderPath src, FolderPath dst, bool overwrite)
        {
            Source = src;
            Target = dst;
            Overwrite = overwrite;
            Kind = SymLinkKind.Directory;
        }            
    }    
}