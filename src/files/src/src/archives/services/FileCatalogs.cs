//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Commands;

    using static sys;

    public class FileCatalogs
    {
        public static void run(IWfChannel channel, CreateFileCatalog cmd)
        {
            var name = FS.identifier(cmd.Source);
            var dst = cmd.Target + FS.file(name, FileKind.Csv);
            var running =  channel.Running($"Adding files from {cmd.Source} to catalog");
            var counter = 0u;
            var paths = bag<FilePath>();
            var rows = bag<ListedFile>();
            void Accept(FilePath file)
            {
                paths.Add(file);
                rows.Add(new ListedFile{
                    Seq = counter++,
                    Size = file.Size.Kb,
                    Path = file,
                    CreateTS = file.Info.CreationTime,
                    UpdateTS = file.Info.LastWriteTime,
                    Attributes = file.Info.Attributes
                });                
            }

            enumerate(channel, cmd.Source, cmd.Match, Accept);

            channel.TableEmit(rows.ToSeq().Sort().Resequence(), dst);
            channel.Ran(running, counter);
        }

        static void enumerate(IWfChannel channel, FolderPath input,  ReadOnlySeq<FileExt> match, Action<FilePath> dst, bool pll = true)
        {
            var src = match.IsEmpty ? FS.enumerate(input,"*.*", true) : FS.enumerate(input, true, match.Storage);
            var counter = 0u;
            var flow = channel.Running($"Searching {input}");
            string msg()
                => $"Collected {counter} files";

            iter(src, file => {
                dst(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, pll);
            channel.Ran(flow, $"Found {counter} files from {input}");
        }
    }
}