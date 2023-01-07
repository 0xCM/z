//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class FileTraversal : Channeled<FileTraversal>, ITraversal<IFsEntry,FileTraversal.Options>
    {    
        public enum TraversalKind
        {
            None,

            Files,

            Folders
        }

        public record struct Options
        {
            public FolderPath Root;

            public TraversalKind Kind;

            public @string Match;
        }

        public Task<ExecToken> Start(Action<IFsEntry> receiver, Options options)
        {
            ExecToken Run()
            {                
                var running = Channel.Running();
                var match = options.Match;
                switch(options.Kind)
                {
                    case TraversalKind.Folders:
                    {
                        iter(Directory.EnumerateDirectories(options.Root.Format(PathSeparator.BS), options.Match, new EnumerationOptions{
                             RecurseSubdirectories = true,
                             AttributesToSkip = FileAttributes.System
                        }), found => receiver(new FolderPath(found)));
                    }
                    break;

                    case TraversalKind.Files:
                    default:

                    break;
                }
                return Channel.Ran(running);
            }

            return sys.start(Run);
        }
    }
}