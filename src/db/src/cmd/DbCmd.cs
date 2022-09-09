//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static DbCmdNames;

    class DbCmd : AppCmdService<DbCmd>
    {
        DbArchive Root => AppDb.DbRoot();

        [CmdOp(purge)]
        void Purge(CmdArgs args)
        {
            var src = FS.relative(arg(args,0).Value);
            var flow = Running("db/purge");
            Db.purge(Root.Root, src, Emitter).ContinueWith(x => Ran(flow));
        }

        [CmdOp(archive)]
        void Zip(CmdArgs args)
        {
            var folder = arg(args,0).Value;
            var i = text.index(folder, Chars.FSlash,Chars.BSlash);
            var scope = "default";
            if(i > 0)
                scope = text.left(folder,i);
            var src = AppDb.DbRoot().Scoped(folder).Root;
            var name = src.FolderName.Format();
            var file = FS.file($"{scope}.{name}", FileKind.Zip);
            var cmd = DbCmdSpecs.archive(src, AppDb.Archive(scope).Path(file));
            
            Db.zip(cmd, Emitter);            
        }

        [CmdOp(jobs)]
        void Jobs(CmdArgs args)
        {
            var src = AppDb.Jobs("queue");
            iter(src.Files(), file => Write(file.ToUri()));
        }
    }
}