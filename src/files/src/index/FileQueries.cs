//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.Extensions.FileSystemGlobbing;
    
    using static sys;

    public class FileQueries
    {
        [MethodImpl(Inline), Op]
        public static SearchPattern pattern(params string[] src)
            => string.Join(Chars.Pipe, src);

        public static FileQuery query(FolderPath src, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            if(ext.Length != 0)
                filter.Extensions = ext;
            else
                filter.Inclusions = array(SearchPattern.All);
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        public static FileQuery query(FolderPath src, string match, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            filter.Extensions = ext;
            filter.Inclusions = array(pattern(match));
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        public abstract class Receiver : IWfTask
        {
            public virtual bool Pll => true;

            public Task<ExecToken> Start(IWfChannel channel)
                => start(channel, Query, this);

            public ExecToken Run(IWfChannel channel)
                => run(channel, Query, this);

            public abstract void Matched(FilePath src);

            public abstract ref readonly FileQuery Query {get;}
        }

        public abstract class Receiver<R> : Receiver
            where R : Receiver<R>, new()
        {
            public static R create(FileQuery query, Action<R> initializer = null)
            {
                var dst = new R();
                dst._Query = query;
                initializer?.Invoke(dst);
                return dst;
            }

            FileQuery _Query;

            public override ref readonly FileQuery Query => ref _Query;
        }

        public static Task<ExecToken> start(IWfChannel channel, FileQuery query, Receiver dst)
            => sys.start(() => run(channel, query,dst));

        public static ExecToken run(IWfChannel channel, FileQuery query, Receiver dst)
        {
            var running = channel.Running($"Executing query over {query.Root}");
            var filter = query.Filter;
            var matcher = new Matcher();  
            iter(filter.Extensions, t => matcher.AddInclude($"${t.SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${Z0.SearchPattern.All}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));
            iter(matcher.GetResultsInFullPath(query.Root.Format()), f => dst.Matched(new FileUri(f)), dst.Pll);
            return channel.Ran(running);
        }
    }
}