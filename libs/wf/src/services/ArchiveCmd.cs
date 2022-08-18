//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    class ArchiveCmd : AppCmdService<ArchiveCmd>
    {
        [CmdOp("archives/zip")]        
        void CreateZip(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var dst = AppDb.Archive(arg(args,1)).Path(src.FolderName.Format(),FileKind.Zip);
            Archives.zip(src, dst, Emitter);
        }

        [CmdOp("archives")]        
        void ListArchives(CmdArgs args)
            => Emitter.Row(AppDb.Archives().Folders().Delimit(Eol));

        [CmdOp("archives/list")]        
        void ArchiveFiles(CmdArgs args)
        {
            var src = AppDb.Archive(arg(args,0).Value);

            iter(src.Files(true), file => Write(file.ToUri()));
        }
    }
}