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
            filter.FileTypes = ext;
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        public static FileQuery query(FolderPath src, string match, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            filter.FileTypes = ext;
            filter.Inclusions = array(pattern(match));
            dst.Root = src;
            dst.Filter = filter;
            return dst;
        }

        public abstract class Receiver
        {
            public virtual bool Pll => true;

            public abstract void Matched(FileUri src);

            public abstract ref readonly FileQuery Query {get;}
        }

        public abstract class Receiver<R> : Receiver
            where R : Receiver<R>, new()
        {
            public static R create(FileQuery query)
            {
                var dst = new R();
                dst._Query = query;
                return dst;
            }

            FileQuery _Query;

            public override ref readonly FileQuery Query => ref _Query;
        }

        public static Task start(FileQuery query, Receiver dst)
            => sys.start(() => run(query,dst));

        public static void run(FileQuery query, Receiver dst)
        {
            var filter = query.Filter;
            var matcher = new Matcher();  
            iter(filter.FileTypes, t => matcher.AddInclude($"${t.SearchPattern}${Z0.SearchPattern.Recurse}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${Z0.SearchPattern.Recurse}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));
            iter(matcher.GetResultsInFullPath(query.Root.Format()), f => dst.Matched(new FileUri(f)), dst.Pll);
        }
    }
}