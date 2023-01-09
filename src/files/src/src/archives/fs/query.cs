//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.FileSystemGlobbing;

    using static sys;

    partial struct FS
    {
        public static IEnumerable<FileUri> query(FileQuery spec)
        {
            var filter = spec.Filter;
            var matcher = new Matcher();  
            iter(filter.FileTypes, t => matcher.AddInclude($"${t.SearchPattern}${Z0.SearchPattern.Recurse}" ));
            iter(filter.FileKinds, t => matcher.AddInclude($"${t.Ext().SearchPattern}${Z0.SearchPattern.Recurse}" ));
            iter(filter.Inclusions, i => matcher.AddInclude(i.Format()));
            iter(filter.Exclusions, x => matcher.AddExclude(x.Format()));        
            var result  = matcher.GetResultsInFullPath(spec.Source.Format());
            foreach(var item in result)
                yield return new FileUri(item);
        }
    }
}